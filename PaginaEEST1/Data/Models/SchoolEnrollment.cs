namespace PaginaEEST1.Data.Models
{
    /// <summary>
    /// Inscripción a la escuela
    /// </summary>
    public class SchoolEnrollment
    {
        public int Id { get; set; }

        /// <summary>
        /// Inicio de la inscripción
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Fin de la inscripción
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Enlace al formulario de Google
        /// </summary>
        public string GoogleFormLink { get; set; } = string.Empty;
    }
}
