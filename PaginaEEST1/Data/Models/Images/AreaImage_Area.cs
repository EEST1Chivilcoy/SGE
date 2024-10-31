using PaginaEEST1.Data.Models.SchoolArea;
using System.ComponentModel.DataAnnotations;

namespace PaginaEEST1.Data.Models.Images
{
    public class AreaImage_Area : AbstractImage
    {
        [Required]
        public Area Area { get; set; } = null!;
        public int AreaId { get; set; }
    }
}
