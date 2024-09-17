using System.ComponentModel;

namespace PaginaEEST1.Data.Enums
{
    public enum NivelDeEstudio
    {
        [Description("Primario Incompleto")]
        PrimarioIncompleto,
        [Description("Primario Completo")]
        PrimarioCompleto,
        [Description("Secundario Incompleto")]
        SecundarioIncompleto,
        [Description("Secundario Completo")]
        SecundarioCompleto,
        [Description("Terciario Incompleto")]
        TerciarioIncompleto,
        [Description("Terciario Completo")]
        TerciarioCompleto,
        [Description("Universitario Incompleto")]
        UniversitarioIncompleto,
        [Description("Universitario Completo")]
        UniversitarioCompleto
    }
}
