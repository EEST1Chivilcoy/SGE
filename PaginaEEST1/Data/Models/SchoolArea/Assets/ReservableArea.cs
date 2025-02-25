using System.ComponentModel.DataAnnotations;

namespace PaginaEEST1.Data.Models.SchoolArea.Assets
{
    /// <summary>
    /// Información sobre la reservabilidad de un área.
    /// </summary>
    public class ReservableArea
    {
        public int Id { get; set; }

        /// <summary>
        /// Horarios en los que el área está disponible para reservas.
        /// </summary>
        [Required]
        public List<AvailableSchedule> AvailableSchedules { get; set; } = new();

        /// <summary>
        /// Lista de reservas realizadas para este área.
        /// </summary>
        public List<Reservation> Reservations { get; set; } = new();
    }
}
