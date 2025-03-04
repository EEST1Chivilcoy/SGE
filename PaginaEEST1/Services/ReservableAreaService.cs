using Microsoft.EntityFrameworkCore;
using PaginaEEST1.Data;
using PaginaEEST1.Data.Models.SchoolArea;
using PaginaEEST1.Data.Models.SchoolArea.Assets;

namespace PaginaEEST1.Services
{
    public interface IReservableAreaService
    {
        Task<ReservableArea?> GetReservableArea(int areaId);
        Task<ReservableArea?> SaveReservableArea(int areaId, ReservableArea reservableArea);
        Task<ReservableArea?> EditReservableArea(ReservableArea newReservableArea);
        Task DelReservableArea(int areaId);

        /* Task<List<AvailableSchedule>> GetSchedules(int areaId);
        Task<List<Reservation>> GetReservations(int areaId); */
    }

    public class ReservableAreaService : IReservableAreaService
    {
        private readonly PaginaDbContext _context;

        public ReservableAreaService(PaginaDbContext context)
        {
            _context = context;
        }

        public async Task<ReservableArea?> GetReservableArea(int areaId)
        {
            return await _context.ReservableAreas
                .Include(r => r.AvailableSchedules)
                .Include(r => r.Reservations)
                .Where(r => r.Id == areaId)
                .SingleOrDefaultAsync();
        }

        public async Task<ReservableArea?> SaveReservableArea(int areaId, ReservableArea reservableArea)
        {
            try
            {
                var area = await _context.Areas.FindAsync(areaId);
                if (area == null)
                    throw new InvalidOperationException("No se encontró el área.");

                reservableArea.Id = area.Id; // Se asegura de que comparten el mismo ID.
                _context.ReservableAreas.Add(reservableArea);
                await _context.SaveChangesAsync();
                return reservableArea;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<ReservableArea?> EditReservableArea(ReservableArea newReservableArea)
        {
            var reservableArea = await _context.ReservableAreas.FindAsync(newReservableArea.Id);
            if (reservableArea == null)
                throw new InvalidOperationException("No se encontró el área reservable.");

            try
            {
                // Realizar Cambios
                // EJ: reservableArea.MaxCapacity = newReservableArea.MaxCapacity;
                await _context.SaveChangesAsync();
                return reservableArea;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                throw new InvalidOperationException("Error al actualizar el área reservable.");
            }
        }

        public async Task DelReservableArea(int areaId)
        {
            var reservableArea = await _context.ReservableAreas.FindAsync(areaId);
            if (reservableArea == null)
                throw new InvalidOperationException("No se encontró el área reservable.");

            _context.ReservableAreas.Remove(reservableArea);
            await _context.SaveChangesAsync();
        }

        /* public async Task<List<AvailableSchedule>> GetSchedules(int areaId)
        {
            // return await _context.AvailableSchedules
            //    .Where(s => s.ReservableAreaId == areaId)
            //    .ToListAsync();
        } */

        /* public async Task<List<Reservation>> GetReservations(int areaId)
        {
            // return await _context.Reservations
            //    .Where(r => r.ReservableAreaId == areaId)
            //    .ToListAsync();
        } */
    }
}
