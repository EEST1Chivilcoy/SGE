using PaginaEEST1.Data.Models.PhysicalObjects.PhysicalAssets.Loan;
using Microsoft.AspNetCore.Components.Authorization;
using PaginaEEST1.Data.Models.PhysicalObjects;
using PaginaEEST1.Data.Models.Personal;
using Microsoft.EntityFrameworkCore;
using PaginaEEST1.Data.ViewModels;
using PaginaEEST1.Data.Enums;
using System.Security.Claims;
using PaginaEEST1.Data;

namespace PaginaEEST1.Services
{
    public interface ILoanService
    {
        Task<List<LoanViewModel>> GetLoanList(TypeLoan typeLoan, bool? forAvailability = false);
        Task<Loan> SaveLoan(Loan save);
        Task<Loan?> GetLoanById(int Id);
        Task<LoanStatus?> UpdateStatus(int Id, LoanStatus status);
        Task CancelLoan(int Id);
    }

    public class LoanService : ILoanService
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly PaginaDbContext _context;

        public LoanService(PaginaDbContext context, AuthenticationStateProvider authenticationStateProvider)
        {
            _context = context;
            _authenticationStateProvider = authenticationStateProvider;
        }
        public async Task<Loan> SaveLoan(Loan save)
        {
            save.Professor = _context.People.OfType<Professor>().Where(p => p.PersonId == save.ProfessorId).SingleOrDefault();
            if (save is NetbookLoan netbookLoan)
            {
                List<Netbook> netbooks = await _context.Computers
                    .OfType<Netbook>()
                    .Where(c => netbookLoan.Netbooks.Select(n => n.Id).Contains(c.Id))
                    .ToListAsync();
                if (save.RequiredDate == DateOnly.FromDateTime(DateTime.Now))
                    netbooks.ForEach(n => n.IsAvailable = false);
                netbookLoan.Netbooks = netbooks;
                _context.Loans.Add(netbookLoan);
                await _context.SaveChangesAsync();
                return save;
            }
            else if (save is ItemLoan itemLoan)
            {
                List<ReturnableItem> items = await _context.Items
                    .OfType<ReturnableItem>()
                    .Where(c => itemLoan.Items.Select(n => n.Id).Contains(c.Id))
                    .ToListAsync();
                itemLoan.Items = items;
                _context.Loans.Add(itemLoan);
                await _context.SaveChangesAsync();
                return save;
            }
            _context.Loans.Add(save);
            await _context.SaveChangesAsync();
            return save;
        }
        public async Task<Loan?> GetLoanById(int id)
        {
            // Cargar el préstamo desde la base de datos
            Loan? loan = await _context.Loans.AsNoTracking().Where(l => l.Id == id).SingleOrDefaultAsync();

            if (loan == null)
                throw new InvalidOperationException("No se encontró el Préstamo.");

            if (loan is NetbookLoan)
            {
                return _context.Loans.OfType<NetbookLoan>().AsNoTracking()
                    .Include(l => l.Netbooks)
                    .Include(l => l.Professor)
                    .Where(l => l == loan)
                    .SingleOrDefault();
            }
            else if(loan is ItemLoan)
            {
                return _context.Loans.OfType<ItemLoan>().AsNoTracking()
                    .Include(l => l.Items)
                    .Include(l => l.Professor)
                    .Where(l => l == loan)
                    .SingleOrDefault();
            }

            return loan;
        }
        public async Task<List<LoanViewModel>> GetLoanList(TypeLoan typeLoan, bool? forAvailability = false)
        {
            // Autenticación 
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            var personIdClaim = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userRole = user.FindFirst(ClaimTypes.Role)?.Value;

            // Cargar los préstamos y assets relacionados en una sola consulta
            var loansQuery = _context.Loans.AsNoTracking();

            if (typeLoan == TypeLoan.NetbookLoan)
            {
                loansQuery = loansQuery
                    .OfType<NetbookLoan>()
                    .Include(loan => loan.Netbooks);
            }
            else if (typeLoan == TypeLoan.ItemLoan)
            {
                loansQuery = loansQuery
                    .OfType<ItemLoan>()
                    .Include(loan => loan.Items);
            }

            var loans = await loansQuery
                .Select(loan => new
                {
                    Id = loan.Id,
                    Status = loan.Status,
                    RequiredDate = loan.RequiredDate,
                    StartTime = loan.StartTime,
                    FinishTime = loan.FinishTime,
                    SchoolGrade = loan.SchoolGrade,
                    ProfessorId = loan.ProfessorId,
                    Assets = typeLoan == TypeLoan.NetbookLoan
                        ? ((NetbookLoan)loan).Netbooks.Select(n => n.DeviceName).ToList()
                        : ((ItemLoan)loan).Items.Select(i => i.Name).ToList()
                })
                .ToListAsync();

            // Si es un profesor, evitar recibir otros prestamos
            if (userRole == "Profesores" && forAvailability == false){
                loans = loans.Where(l => l.ProfessorId == personIdClaim).ToList();
            }

            // Transformar a ViewModel
            List<string?> LoanAssets = new();


            return loans.Select(loan => new LoanViewModel
            {
                Id = loan.Id,
                Type = typeLoan,
                Status = loan.Status,
                RequiredDate = loan.RequiredDate,
                StartTime = loan.StartTime,
                FinishTime = loan.FinishTime,
                SchoolGrade = loan.SchoolGrade,
                Professor = loan.ProfessorId,
                Assets = loan.Assets.Distinct().ToList()
            }).ToList();
        }
        public async Task<LoanStatus?> UpdateStatus(int Id, LoanStatus status )
        {
            Loan? loan = await _context.Loans.Where(l => l.Id == Id).SingleOrDefaultAsync();

            if (loan == null || loan.Status == status) return null;

            loan.Status = status;

            if (status == LoanStatus.Returned && loan.RequiredDate == DateOnly.FromDateTime(DateTime.Now)
                && loan is NetbookLoan netbookLoan && netbookLoan.Netbooks != null)
                    netbookLoan.Netbooks.ForEach(n => n.IsAvailable = true);

            _context.SaveChanges();
            return loan.Status;
        }
        public async Task CancelLoan(int Id)
        {
            Loan? loan = await _context.Loans.Where(l => l.Id == Id).SingleOrDefaultAsync();

            if (loan == null) return;

            if(loan is NetbookLoan netbookLoan && loan.RequiredDate == DateOnly.FromDateTime(DateTime.Now)
                && netbookLoan.Netbooks != null)
                    netbookLoan.Netbooks.ForEach(n => n.IsAvailable = true);

            _context.Loans.Remove(loan);
            _context.SaveChanges();

            return;
        }
    }
}
