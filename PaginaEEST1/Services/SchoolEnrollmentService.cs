using PaginaEEST1.Data;
using Microsoft.EntityFrameworkCore;
using PaginaEEST1.Data.Models;

namespace PaginaEEST1.Services
{
    public interface ISchoolEnrollmentService
    {
        Task<SchoolEnrollment?> GetCurrentEnrollmentAsync();
        Task<bool> HasActiveEnrollmentAsync();
        Task<SchoolEnrollment> CreateEnrollmentAsync(SchoolEnrollment enrollment);
        Task<SchoolEnrollment> UpdateEnrollmentAsync(SchoolEnrollment enrollment);
    }

    public class SchoolEnrollmentService : ISchoolEnrollmentService
    {
        private readonly PaginaDbContext _context;

        public SchoolEnrollmentService(PaginaDbContext context)
        {
            _context = context;
        }

        public async Task<SchoolEnrollment?> GetCurrentEnrollmentAsync()
        {
            return await _context.Set<SchoolEnrollment>().FirstOrDefaultAsync();
        }

        public async Task<bool> HasActiveEnrollmentAsync()
        {
            return await _context.Set<SchoolEnrollment>().AnyAsync();
        }

        public async Task<SchoolEnrollment> CreateEnrollmentAsync(SchoolEnrollment enrollment)
        {
            if (await HasActiveEnrollmentAsync())
            {
                throw new InvalidOperationException("There is already an active enrollment.");
            }

            _context.Set<SchoolEnrollment>().Add(enrollment);
            await _context.SaveChangesAsync();
            return enrollment;
        }

        public async Task<SchoolEnrollment> UpdateEnrollmentAsync(SchoolEnrollment enrollment)
        {
            var existingEnrollment = await GetCurrentEnrollmentAsync();
            if (existingEnrollment == null)
            {
                throw new KeyNotFoundException("No enrollment found to update.");
            }

            existingEnrollment.StartDate = enrollment.StartDate;
            existingEnrollment.EndDate = enrollment.EndDate;
            existingEnrollment.GoogleFormLink = enrollment.GoogleFormLink;

            await _context.SaveChangesAsync();
            return existingEnrollment;
        }
    }
}