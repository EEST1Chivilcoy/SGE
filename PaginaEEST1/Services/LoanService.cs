using PaginaEEST1.Data.Models.PhysicalObjects.PhysicalAssets.Loan;
using Microsoft.EntityFrameworkCore;
using PaginaEEST1.Data;
using PaginaEEST1.Data.Enums;
using PaginaEEST1.Data.Models.PhysicalObjects;
using PaginaEEST1.Data.Models.Personal;
using PaginaEEST1.Data.Models.Categories;
using static PaginaEEST1.Components.Pages.Modals.Loans.RequestLoan;
using PaginaEEST1.Data.ViewModels;

namespace PaginaEEST1.Services
{
    public interface ILoanService
    {
        Task<List<NetbookLoanViewModel>> GetNetbookLoans();
        Task<List<Netbook>> GetListNetbooks();
        Task<Loan> SaveLoan(Loan save);
    }

    public class LoanService : ILoanService
    {
        private readonly PaginaDbContext _context;

        public LoanService(PaginaDbContext context)
        {
            _context = context;
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
                foreach(Netbook netbook in netbooks)
                {
                    netbook.IsAvailable = false;
                }
                netbookLoan.Netbooks = netbooks;
                _context.Loans.Add(netbookLoan);
                await _context.SaveChangesAsync();
                return save;
            }
            _context.Loans.Add(save);
            await _context.SaveChangesAsync();
            return save;
        }
        public async Task<List<NetbookLoanViewModel>> GetNetbookLoans()
        {
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
        public async Task<List<Netbook>> GetListNetbooks()
        {
            return await _context.Computers.AsNoTracking()
                .OfType<Netbook>()
                .Where(n => n.IsAvailable == true)
                .ToListAsync();
        }
    }

}
