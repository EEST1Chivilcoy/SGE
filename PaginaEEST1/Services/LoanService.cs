using PaginaEEST1.Data.Models.PhysicalObjects.PhysicalAssets.Loan;
using Microsoft.EntityFrameworkCore;
using PaginaEEST1.Data;
using PaginaEEST1.Data.Enums;
using PaginaEEST1.Data.Models.PhysicalObjects;
using PaginaEEST1.Data.Models.Personal;
using PaginaEEST1.Data.Models.Categories;
using static PaginaEEST1.Components.Pages.Modals.Loans.RequestLoan;

namespace PaginaEEST1.Services
{
    public interface ILoanService
    {
        Task<List<Loan>> GetListLoans(TypeLoan typeLoan);
        Task<List<Netbook>> GetListNetbooks();
        List<string> GetDeviceNames(int loanId);
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
                netbookLoan.Netbooks = await _context.Computers
                    .OfType<Netbook>()
                    .Where(c => netbookLoan.Netbooks.Select(n => n.Id).Contains(c.Id))
                    .ToListAsync();
                _context.Loans.Add(netbookLoan);
                await _context.SaveChangesAsync();
                return save;
            }
            _context.Loans.Add(save);
            await _context.SaveChangesAsync();
            return save;
        }
        public async Task<List<Loan>> GetListLoans(TypeLoan typeLoan)
        {
            return await _context.Loans.AsNoTracking()
                .Where(l => l.Type == typeLoan && l != null)
                .ToListAsync();
        }
        public List<string> GetDeviceNames(int loanId)
        {
            NetbookLoan loan = _context.Loans.OfType<NetbookLoan>().Where(n => n.Id == loanId).SingleOrDefault();
            List<string> names = _context.Computers.AsNoTracking().OfType<Netbook>()
                .Where(c => loan.Netbooks.Select(n => n.Id).Contains(c.Id))
                .Select(c => c.DeviceName).Distinct().ToList();
            return names;
        }
        public async Task<List<Netbook>> GetListNetbooks()
        {
            return await _context.Computers.AsNoTracking().OfType<Netbook>().ToListAsync();
        }
    }

}
