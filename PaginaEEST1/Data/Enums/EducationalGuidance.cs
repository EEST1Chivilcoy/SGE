using System.ComponentModel.DataAnnotations;

namespace PaginaEEST1.Data.Enums
{
    public enum EducationalGuidance
    {
        [Display(Name = "Ninguno")]
        None = 0,
        [Display(Name = "Informática")]
        Computing = 1,
        [Display(Name = "Electromecánica")]
        Electromechanical = 2
    }
}
