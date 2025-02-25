using System.ComponentModel.DataAnnotations;

namespace PaginaEEST1.Data.Models.SchoolArea.Assets
{
    /// <summary>
    /// Horario disponible para reservas de un área.
    /// </summary>
    public class AvailableSchedule
    {
        public int Id { get; set; }

        /// <summary>
        /// Día de la semana en el que está disponible.
        /// </summary>
        [Required]
        public DayOfWeek Day { get; set; }

        /// <summary>
        /// Hora de apertura del área para reservas.
        /// </summary>
        [Required]
        public TimeSpan OpeningTime { get; set; }

        /// <summary>
        /// Hora de cierre del área para reservas.
        /// </summary>
        [Required]
        public TimeSpan ClosingTime { get; set; }
    }
}
