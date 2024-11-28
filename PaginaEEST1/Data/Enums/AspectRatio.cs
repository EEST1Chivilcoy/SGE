using System.ComponentModel.DataAnnotations;

namespace PaginaEEST1.Data.Enums
{
    public enum AspectRatio
    {
        [Display(Name = "16:9")]
        SixteenNine,

        [Display(Name = "4:3")]
        FourThree,

        [Display(Name = "21:9")]
        TwentyOneNine,

        [Display(Name = "Desconocido")]
        Unknown
    }
}
