using PaginaEEST1.Data.Models.Personal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PaginaEEST1.Data.Enums
{
    public enum LoanStatus
    {
        [Display(Name = "Pendiente")]
        Pending,
        [Display(Name = "En uso")]
        Busy,
        [Display(Name = "Entregado")]
        Returned
    }
}
