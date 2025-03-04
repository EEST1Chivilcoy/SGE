using Microsoft.EntityFrameworkCore;
using PaginaEEST1.Data;
using PaginaEEST1.Data.Models.SchoolArea.Assets;

namespace PaginaEEST1.Services
{
    public interface IReservationService
    {
        Task<Reservation?> GetReservation(int reservationId);
        Task<List<Reservation>> GetReservationsByArea(int areaId);
        Task<Reservation?> CreateReservation(Reservation newReservation);
        Task<Reservation?> EditReservation(Reservation updatedReservation);
        Task DeleteReservation(int reservationId);
    }

    public class ReservationService : IReservationService
    {
        private readonly PaginaDbContext _context;

        public ReservationService(PaginaDbContext context)
        {
            _context = context;
        }

        public async Task<Reservation?> GetReservation(int reservationId)
        {
            return await _context.Reservations
                .Include(r => r.ReservableArea)
                .Where(r => r.Id == reservationId)
                .SingleOrDefaultAsync();
        }

        public async Task<List<Reservation>> GetReservationsByArea(int areaId)
        {
            return await _context.Reservations
                .Where(r => r.ReservableAreaId == areaId)
                .ToListAsync();
        }

        public async Task<Reservation?> CreateReservation(Reservation newReservation)
        {
            try
            {
                // 🛑 Validación: No permitir reservas en horarios ocupados
                bool isConflicting = await _context.Reservations.AnyAsync(r =>
                    r.ReservableAreaId == newReservation.ReservableAreaId &&
                    ((newReservation.StartTime >= r.StartTime && newReservation.StartTime < r.EndTime) ||
                     (newReservation.EndTime > r.StartTime && newReservation.EndTime <= r.EndTime) ||
                     (newReservation.StartTime <= r.StartTime && newReservation.EndTime >= r.EndTime))
                );

                if (isConflicting)
                    throw new InvalidOperationException("El horario seleccionado ya está reservado.");

                _context.Reservations.Add(newReservation);
                await _context.SaveChangesAsync();
                return newReservation;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<Reservation?> EditReservation(Reservation updatedReservation)
        {
            var existingReservation = await _context.Reservations.FindAsync(updatedReservation.Id);
            if (existingReservation == null)
                throw new InvalidOperationException("No se encontró la reserva.");

            try
            {
                // 🛑 Validación: No permitir cambios que generen conflictos de horario
                bool isConflicting = await _context.Reservations.AnyAsync(r =>
                    r.ReservableAreaId == updatedReservation.ReservableAreaId &&
                    r.Id != updatedReservation.Id && // Excluye la reserva actual
                    ((updatedReservation.StartTime >= r.StartTime && updatedReservation.StartTime < r.EndTime) ||
                     (updatedReservation.EndTime > r.StartTime && updatedReservation.EndTime <= r.EndTime) ||
                     (updatedReservation.StartTime <= r.StartTime && updatedReservation.EndTime >= r.EndTime))
                );

                if (isConflicting)
                    throw new InvalidOperationException("El nuevo horario entra en conflicto con otra reserva.");

                existingReservation.StartTime = updatedReservation.StartTime;
                existingReservation.EndTime = updatedReservation.EndTime;
                existingReservation.UserId = updatedReservation.UserId;

                await _context.SaveChangesAsync();
                return existingReservation;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                throw new InvalidOperationException("Error al actualizar la reserva.");
            }
        }

        public async Task DeleteReservation(int reservationId)
        {
            var reservation = await _context.Reservations.FindAsync(reservationId);
            if (reservation == null)
                throw new InvalidOperationException("No se encontró la reserva.");

            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
        }
    }
}
