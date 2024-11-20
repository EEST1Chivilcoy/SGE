using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using PaginaEEST1.Data.Enums;
using PaginaEEST1.Data.Models.Images;

namespace PaginaEEST1.Data.Models.Personal
{
    public abstract class Person
    {
        public string PersonId { get; set; } = null!;
        public TypePerson TypePerson { get; set; }
        public TypeGender Gender { get; set; }
        [Required, StringLength(255)]
        public string? Name { get; set; }
        [Required, StringLength(255)]
        public string? Surname { get; set; }
        [Required, StringLength(255)]
        public string? Email { get; set; }
        [Required, StringLength(255)]
        public string? EntraIDRole { get; set; }
        public ProfileImage_Person? ProfileImage { get; set; }
    }
}
