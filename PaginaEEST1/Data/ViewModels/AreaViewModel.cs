using PaginaEEST1.Data.Enums;

namespace PaginaEEST1.Data.ViewModels
{
    public class AreaViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int? ImageId { get; set; }
    }
}
