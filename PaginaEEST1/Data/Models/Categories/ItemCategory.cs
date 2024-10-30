using PaginaEEST1.Data.Models.PhysicalObjects;

namespace PaginaEEST1.Data.Models.Categories
{
    public class ItemCategory : Category
    {
        public List<Item>? Items { get; set; }
    }
}
