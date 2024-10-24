using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using PaginaEEST1.Data.Enums;
using PaginaEEST1.Data.Models.People.PeopleAssets;

namespace PaginaEEST1.Data.Models.Personal
{
    public class Professor : Person
    {
        [StringLength(255)]
        public EducationLevels? EducationLevel { get; set; }
        public List<Attendance> Attendances { get; set; } = new List<Attendance>();
    }
}
