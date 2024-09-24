using PaginaEEST1.Data.Models.Personal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PaginaEEST1.Data.Enums
{
    public enum ComputerStatus
    {
        [Display(Name = "Operativo al 100%")]
        Operativo,
        [Display(Name = "Presenta fallas")]
        Fallas,
        [Display(Name = "En mantenimiento")]
        Mantenimiento
    }
}
