using PaginaEEST1.Data.Models.Personal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaginaEEST1.Data.Models.Images
{
    public class ProfileImage_Person : AbstractImage
    {
        [Required]
        public Person Person { get; set; } = null!;
        public string PersonId { get; set; } = null!;
    }
}
