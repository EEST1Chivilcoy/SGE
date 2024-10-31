using PaginaEEST1.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace PaginaEEST1.Data.Models.Images
{
    public abstract class AbstractImage
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string? ImageName { get; set; }

        [Required]
        public string Base64Image { get; set; } = string.Empty;
        public TypeImage ImageType { get; set; }
    }
}
