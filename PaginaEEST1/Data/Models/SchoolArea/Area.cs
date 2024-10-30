using System.Security.AccessControl;
using PaginaEEST1.Data.Enums;
using PaginaEEST1.Data.Models.Categories;

namespace PaginaEEST1.Data.Models.SchoolArea
{
    public class Area
    {
        public int Id { get; set; }
        /// <summary>
        /// Nombre del área (por ejemplo, "INFO3", "Biblioteca", "Audiovisuales")
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// Ubicación en el edificio
        /// </summary>
        public string Location { get; set; } = null!;
        /// <summary>
        /// Indica si el área es de uso común o privada
        /// </summary>
        public TypeArea AreaType { get; set; }
        /// <summary>
        /// Representa la categoría del área.
        /// </summary>
        public AreaCategory? Category  { get; set; }
    }
}
