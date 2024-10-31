using PaginaEEST1.Data.Models.PhysicalObjects;
using System.ComponentModel.DataAnnotations;

namespace PaginaEEST1.Data.Models.Images
{
    public class ItemImage_Item : AbstractImage
    {
        [Required]
        public Item Item { get; set; } = null!;
        public int ItemId { get; set; }
    }
}
