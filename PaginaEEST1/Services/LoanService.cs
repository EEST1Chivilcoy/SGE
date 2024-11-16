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
        Task<List<NetbookLoanViewModel>> GetNetbookLoans();
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
                netbookLoan.Netbooks = netbooks;
                _context.Loans.Add(netbookLoan);
                await _context.SaveChangesAsync();
                return save;
            }
            _context.Loans.Add(save);
            await _context.SaveChangesAsync();
            return save;
        }
        public async Task<Loan?> GetLoanById(int Id)
        {
            Loan? loan = await _context.Loans.AsNoTracking().Where(l => l.Id == Id).SingleOrDefaultAsync();

            if (loan == null)
                throw new InvalidOperationException("No se encontró el Prestamo.");

            return loan;
        }
        public async Task<List<NetbookLoanViewModel>> GetNetbookLoans()
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            var personIdClaim = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userRole = user.FindFirst(ClaimTypes.Role)?.Value;

            // Cargar los préstamos y sus netbooks relacionados en una sola consulta
            var loans = await _context.Loans
                .OfType<NetbookLoan>()
                .AsNoTracking()
                .Include(loan => loan.Netbooks)
                .Select(loan => new 
                {
                    Id = loan.Id,
                    Status = loan.Status,
                    RequiredDate = loan.RequiredDate,
                    StartTime = loan.StartTime,
                    FinishTime = loan.FinishTime,
                    SchoolGrade = loan.SchoolGrade,
                    ProfessorId = loan.ProfessorId,
                    Netbooks = loan.Netbooks.Select(n => n.DeviceName).ToList()
                })
                .ToListAsync();

            // Si es un profesor, evitar recibir otros prestamos
            if (userRole == "Profesores"){
                loans = loans.Where(l => l.ProfessorId == personIdClaim).ToList();
            }

            // Transformar a ViewModel
            return loans.Select(loan => new NetbookLoanViewModel
            {
                Id = loan.Id,
                Status = loan.Status,
                RequiredDate = loan.RequiredDate,
                StartTime = loan.StartTime,
                FinishTime = loan.FinishTime,
                SchoolGrade = loan.SchoolGrade,
                ProfessorId = loan.ProfessorId,
                Netbooks = loan.Netbooks.Distinct().ToList()
            }).ToList();
        }
        public async Task<LoanStatus?> UpdateStatus(int Id, LoanStatus status )
        {
            Loan? loan = await _context.Loans.Where(l => l.Id == Id).SingleOrDefaultAsync();

            if (loan == null || loan.Status == status) return null;

            loan.Status = status;

            if (status == LoanStatus.Returned && loan.RequiredDate == DateOnly.FromDateTime(DateTime.Now)
                && loan is NetbookLoan netbookLoan && netbookLoan.Netbooks != null)
            {
                foreach(Netbook netbook in netbookLoan.Netbooks)
                {
                    netbook.IsAvailable = true;
                }
            }

            _context.SaveChanges();
            return loan.Status;
        }
        public async Task CancelLoan(int Id)
        {
            Loan? loan = await _context.Loans.Where(l => l.Id == Id).SingleOrDefaultAsync();

            if (loan == null) return;

            if(loan is NetbookLoan netbookLoan && loan.RequiredDate == DateOnly.FromDateTime(DateTime.Now)
                && netbookLoan.Netbooks != null)
            {
                foreach(Netbook netbook in netbookLoan.Netbooks)
                {
                    netbook.IsAvailable = true;
                }
            }

            _context.Loans.Remove(loan);
            _context.SaveChanges();

            return;
        }
    }
}
