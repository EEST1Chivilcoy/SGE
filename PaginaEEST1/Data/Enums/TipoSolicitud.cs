using System.ComponentModel.DataAnnotations;

namespace PaginaEEST1.Data.Enums
{
    public enum TipoSolicitud
    {
        [Display(Name = "Instalación de un Programa")]
        Instalacion = 1,  // Instalación de programa
        [Display(Name = "Reporte de Fallos")]
        ReporteFallo = 2 // Reporte de fallo en el PC
    }
}
