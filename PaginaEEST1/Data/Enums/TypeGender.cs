using System.ComponentModel.DataAnnotations;

namespace PaginaEEST1.Data.Enums
{
    public enum TypeGender
    {
        [Display(Name = "Hombre")]
        Hombre,
        [Display(Name = "Mujer")]
        Mujer,
        [Display(Name = "Otro")]
        Otro
    }
}
