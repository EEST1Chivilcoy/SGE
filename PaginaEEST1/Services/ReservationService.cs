using Microsoft.EntityFrameworkCore;
using PaginaEEST1.Data;
using PaginaEEST1.Data.Models.SchoolArea.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaginaEEST1.Services
{
    public interface IReservationService
    {
        Task<Reservation?> GetReservation(int reservationId);
        Task<List<Reservation>> GetReservationsByArea(int areaId);
        Task<Reservation?> CreateReservation(int areaId, Reservation newReservation);
        Task<Reservation?> EditReservation(Reservation updatedReservation);
        Task DeleteReservation(int reservationId);
        Task<bool> IsTimeSlotAvailable(int areaId, DateTime startTime, DateTime endTime, int? excludeReservationId = null);
        Task<List<AvailableSchedule>> GetAreaSchedules(int areaId);
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
                .Where(r => r.Id == reservationId)
                .SingleOrDefaultAsync();
        }

        public async Task<List<Reservation>> GetReservationsByArea(int areaId)
        {
            var area = await _context.ReservableAreas
                .Include(a => a.Reservations)
                .FirstOrDefaultAsync(a => a.Id == areaId);

            return area?.Reservations ?? new List<Reservation>();
        }

        public async Task<List<AvailableSchedule>> GetAreaSchedules(int areaId)
        {
            var area = await _context.ReservableAreas
                .Include(a => a.AvailableSchedules)
                .FirstOrDefaultAsync(a => a.Id == areaId);

            return area?.AvailableSchedules ?? new List<AvailableSchedule>();
        }

        public async Task<bool> IsTimeSlotAvailable(int areaId, DateTime startTime, DateTime endTime, int? excludeReservationId = null)
        {
            // 1. Verificar que la fecha/hora está dentro de los horarios disponibles del área
            var area = await _context.ReservableAreas
                .Include(a => a.AvailableSchedules)
                .FirstOrDefaultAsync(a => a.Id == areaId);

            if (area == null)
                return false;

            DayOfWeek reservationDay = startTime.DayOfWeek;
            TimeSpan reservationStartTime = startTime.TimeOfDay;
            TimeSpan reservationEndTime = endTime.TimeOfDay;

            // Verificar si el día y hora de la reserva está dentro de algún horario disponible
            bool isWithinAvailableSchedule = area.AvailableSchedules.Any(schedule =>
                schedule.Day == reservationDay &&
                schedule.OpeningTime <= reservationStartTime &&
                schedule.ClosingTime >= reservationEndTime
            );

            if (!isWithinAvailableSchedule)
                return false;

            // 2. Verificar que no hay conflictos con otras reservas existentes
            var query = _context.ReservableAreas
                .Include(a => a.Reservations)
                .Where(a => a.Id == areaId)
                .SelectMany(a => a.Reservations)
                .Where(r =>
                    (startTime >= r.StartTime && startTime < r.EndTime) ||
                    (endTime > r.StartTime && endTime <= r.EndTime) ||
                    (startTime <= r.StartTime && endTime >= r.EndTime)
                );

            // Si estamos actualizando una reserva existente, excluirla de la verificación
            if (excludeReservationId.HasValue)
            {
                query = query.Where(r => r.Id != excludeReservationId.Value);
            }

            // Si hay reservas que se solapan, el horario no está disponible
            return !await query.AnyAsync();
        }

        public async Task<Reservation?> CreateReservation(int areaId, Reservation newReservation)
        {
            try
            {
                // Validar que el horario está disponible
                bool isAvailable = await IsTimeSlotAvailable(areaId, newReservation.StartTime, newReservation.EndTime);

                if (!isAvailable)
                    throw new InvalidOperationException("El horario seleccionado no está disponible para reserva.");

                // Buscar el área a la que se le agregará la reserva
                var area = await _context.ReservableAreas
                    .Include(a => a.Reservations)
                    .FirstOrDefaultAsync(a => a.Id == areaId);

                if (area == null)
                    throw new InvalidOperationException("No se encontró el área reservable.");

                // Agregar la reserva al área
                area.Reservations.Add(newReservation);
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
                // Primero, encontrar a qué área pertenece esta reserva
                var reservationArea = await _context.ReservableAreas
                    .Include(a => a.Reservations)
                    .FirstOrDefaultAsync(a => a.Reservations.Any(r => r.Id == updatedReservation.Id));

                if (reservationArea == null)
                    throw new InvalidOperationException("No se encontró el área asociada a esta reserva.");

                // Verificar disponibilidad excluyendo la reserva actual
                bool isAvailable = await IsTimeSlotAvailable(
                    reservationArea.Id,
                    updatedReservation.StartTime,
                    updatedReservation.EndTime,
                    updatedReservation.Id);

                if (!isAvailable)
                    throw new InvalidOperationException("El nuevo horario no está disponible para reserva.");

                // Actualizar los datos de la reserva
                existingReservation.StartTime = updatedReservation.StartTime;
                existingReservation.EndTime = updatedReservation.EndTime;
                existingReservation.ReservedBy = updatedReservation.ReservedBy;

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