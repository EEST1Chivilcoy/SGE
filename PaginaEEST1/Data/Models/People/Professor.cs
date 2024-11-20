using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using PaginaEEST1.Data.Enums;
using PaginaEEST1.Data.Models.People;
using PaginaEEST1.Data.Models.People.PeopleAssets;

namespace PaginaEEST1.Data.Models.Personal
{
    public class Professor : SchoolEmployee
    {
        [StringLength(255)]
        public EducationLevels? EducationLevel { get; set; }
    }
}
