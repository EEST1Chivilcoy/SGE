using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using PaginaEEST1.Data.Enums;

namespace PaginaEEST1.Data.Models.Personal
{
    public abstract class Person
    {
        public int PersonId { get; set; }
        public TypePerson TypePerson { get; set; }
        public DateTime? BirthDate { get; set; }
        public TypeGender Gender { get; set; }
        [Required, StringLength(255)]
        public string? Name { get; set; }
        [Required, StringLength(255)]
        public string? Surname { get; set; }
        [StringLength(255)]
        public string? Address { get; set; }
        [StringLength(255)]
        public string? IDCard { get; set; }
    }
}
