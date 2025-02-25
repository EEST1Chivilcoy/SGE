using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using PaginaEEST1.Data.Enums;
using PaginaEEST1.Data.Models.Categories;
using PaginaEEST1.Data.Models.Images;
using PaginaEEST1.Data.Models.SchoolArea.Assets;

namespace PaginaEEST1.Data.Models.SchoolArea
{
    /// <summary>
    /// Representa un área dentro de la escuela.
    /// </summary>
    public class Area
    {
        public int Id { get; set; }

        /// <summary>
        /// Nombre del área (por ejemplo, "INFO3", "Biblioteca", "Audiovisuales")
        /// </summary>
        [Required]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Ubicación en el edificio
        /// </summary>
        [Required]
        public string Location { get; set; } = null!;

        /// <summary>
        /// Indica si el área es de uso común o privada
        /// </summary>
        [Required]
        public TypeArea AreaType { get; set; }

        /// <summary>
        /// Representa la categoría del área.
        /// </summary>
        public AreaCategory? Category  { get; set; }

        /// <summary>
        /// Imagen del área.
        /// </summary>
        public AreaImage_Area? ImageArea { get; set; }

        /// <summary>
        /// Indica la orientación dedicada del área según: Ninguna, Informática, Electromecánica
        /// </summary>
        [Required]
        public EducationalGuidance AreaGuidance { get; set; }

        /// <summary>
        /// Información sobre la reservabilidad del área (si aplica).
        /// </summary>
        public ReservableArea? ReservableInfo { get; set; }
    }
}
