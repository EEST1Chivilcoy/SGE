using PaginaEEST1.Data.Enums;
using PaginaEEST1.Data.Models.Categories;

namespace PaginaEEST1.Data.ViewModels
{
    public class ItemViewModel
    {
        public int ID { get; set; }
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
        /// Categoria del Objeto
        /// </summary>
        public string? Category { get; set; }
        /// <summary>
        /// ID de la Imagen relacionada con el Item
        /// </summary>
        public int? IdImageItem { get; set; }
        /// <summary>
        /// URL de la Imagen relacionada con el Item
        /// </summary>
        public string ImageUrl => IdImageItem.HasValue ? $"/api/Images/{IdImageItem}" : "/Images/default_item.png";
    }
}
