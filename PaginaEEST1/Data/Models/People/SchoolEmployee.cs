using PaginaEEST1.Data.Models.Personal;
using PaginaEEST1.Data.Models.People.PeopleAssets;

namespace PaginaEEST1.Data.Models.People
{
    public class SchoolEmployee : Person
    {
        public List<Attendance> Attendances { get; set; } = new List<Attendance>();
    }
}
