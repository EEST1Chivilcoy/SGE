using System.ComponentModel.DataAnnotations;

namespace PaginaEEST1.Data.Enums
{
    public enum TypeGender
    {
        [Display(Name = "Hombre")]
        Male,
        [Display(Name = "Mujer")]
        Female,
        [Display(Name = "Otro")]
        Other
    }
}
