using PaginaEEST1.Data.Enums;
using PaginaEEST1.Data.Models.Categories;

namespace PaginaEEST1.Data.Models.PhysicalObjects
{
    public abstract class Item
    {
        public int Id { get; set; }
        /// <summary>
        /// Tipo de Objeto (Consumible o No Consumible)
        /// </summary>
        public TypeItem Type { get; set; }
        /// <summary>
        /// Nombre del Objeto
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// Codigo del Objeto
        /// </summary>
        public string Code { get; set; } = null!;
        /// <summary>
        /// Descripción del Objeto
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Orientación de la Escuela dueña del Objeto
        /// </summary>
        public EducationalGuidance Owner { get; set; }
        /// <summary>
        /// Categoria del Objeto
        /// </summary>
        public ItemCategory? Category { get; set; }
        /// <summary>
        /// Propiedad para definir si se debe devolver un elemento
        /// </summary>
        public abstract bool RequiresReturn { get; }
    }
}
