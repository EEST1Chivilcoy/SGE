using PaginaEEST1.Data.Models.Personal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PaginaEEST1.Data.Enums
{
    public enum TypePerson
    {
        [Display(Name = "Directivo")]
        SchoolDirector = 1,
        [Display(Name = "EMATP")]
        EMATP = 2,
        [Display(Name = "Pañol")]
        Warehouse = 3,
        [Display(Name = "Profesor")]
        Teacher = 4,
        [Display(Name = "Alumno")]
        Student = 5,
        [Display(Name = "Empleado de la Escuela")]
        SchoolEmployee = 6
    }
}
