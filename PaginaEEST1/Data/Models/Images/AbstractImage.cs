using PaginaEEST1.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaginaEEST1.Data.Models.Images
{
    public abstract class AbstractImage
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string? ImageName { get; set; }

        [Required]
        public byte[] ImageContent { get; set; } = null!;

        [Required]
        /// <summary>
        /// MIME Type
        /// </summary>
        public string TypeFile { get; set; } = null!;
        
        public TypeImage ImageType { get; set; }
    }
}
