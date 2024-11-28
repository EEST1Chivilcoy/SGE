using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PaginaEEST1.Data.Enums
{
    public enum Resolutions
    {
        [Display(Name = "HD")]
        HD,

        [Display(Name = "Full HD")]
        FullHD,

        [Display(Name = "QHD")]
        QHD,

        [Display(Name = "UHD")]
        UHD,

        [Display(Name = "Desconocido")]
        Unknown
    }
}
