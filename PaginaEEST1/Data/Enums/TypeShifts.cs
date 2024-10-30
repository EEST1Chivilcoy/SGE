using System.ComponentModel.DataAnnotations;

namespace PaginaEEST1.Data.Enums
{
    public enum TypeShifts
    {
        [Display(Name = "Mañana")]
        Morning,
        [Display(Name = "Tarde")]
        Afternoon,
        [Display(Name = "Nocturno")]
        Night
    }
}
