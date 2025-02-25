using System.ComponentModel.DataAnnotations;

namespace PaginaEEST1.Data.Models.SchoolArea.Assets
{
    public class Reservation
    {
        public int Id { get; set; }

        /// <summary>
        /// Fecha y hora de inicio de la reserva.
        /// </summary>
        [Required]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Fecha y hora de finalización de la reserva.
        /// </summary>
        [Required]
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Persona o grupo que realizó la reserva.
        /// </summary>
        [Required]
        public string ReservedBy { get; set; } = null!;
    }
}
