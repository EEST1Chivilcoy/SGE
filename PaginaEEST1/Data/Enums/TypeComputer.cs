using PaginaEEST1.Data.Models.Personal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PaginaEEST1.Data.Enums
{
    public enum TypeComputer
    {
        [Display(Name = "Computadora")]
        Computer = 1,
        [Display(Name = "Netbook")]
        Netbook = 2
    }
}
