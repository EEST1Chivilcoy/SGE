using PaginaEEST1.Data.Enums;

namespace PaginaEEST1.Data.Models.Categories
{
    public abstract class Category
    {
        public int Id { get; set; }
        public TypeCategory Type { get; set; }
        public string Name { get; set; } = null!;
    }
}
