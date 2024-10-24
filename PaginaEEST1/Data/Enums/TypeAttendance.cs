using PaginaEEST1.Data.Models.Personal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PaginaEEST1.Data.Enums
{
    public enum TypeAttendance
    {
        [Display(Name = "Entrada")]
        Entry,
        [Display(Name = "Salida")]
        Exit
    }
}
