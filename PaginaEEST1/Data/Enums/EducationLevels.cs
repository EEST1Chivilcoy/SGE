using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PaginaEEST1.Data.Enums
{
    public enum EducationLevels
    {
        [Display(Name = "Primario Incompleto")]
        PrimarioIncompleto,
        [Display(Name = "Primario Completo")]
        PrimarioCompleto,
        [Display(Name = "Secundario Incompleto")]
        SecundarioIncompleto,
        [Display(Name = "Secundario Completo")]
        SecundarioCompleto,
        [Display(Name = "Terciario Incompleto")]
        TerciarioIncompleto,
        [Display(Name = "Terciario Completo")]
        TerciarioCompleto,
        [Display(Name = "Universitario Incompleto")]
        UniversitarioIncompleto,
        [Display(Name = "Universitario Completo")]
        UniversitarioCompleto
    }
}
