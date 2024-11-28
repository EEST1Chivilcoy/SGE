using System.ComponentModel.DataAnnotations;

namespace PaginaEEST1.Data.Enums
{
    public enum MonitorConnectionType
    {
        [Display(Name = "HDMI")]
        HDMI,

        [Display(Name = "DisplayPort")]
        DisplayPort,

        [Display(Name = "VGA")]
        VGA,

        [Display(Name = "DVI-A")]
        DVIA,

        [Display(Name = "DVI-D")]
        DVID,

        [Display(Name = "DVI-I")]
        DVII,

        [Display(Name = "Desconocido")]
        Unknown
    }
}
