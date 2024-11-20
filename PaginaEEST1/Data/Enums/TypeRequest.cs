using System.ComponentModel.DataAnnotations;

namespace PaginaEEST1.Data.Enums
{
    public enum TypeRequest //Pasar a Ingles (Pronto)
    {
        [Display(Name = "Instalación de un Programa")]
        ProgramInstallation = 1,
        [Display(Name = "Reporte de Fallos")]
        FailureReport = 2,
        [Display(Name = "Solicitud de Cuenta Estudiantil")]
        StudentAccountRequest = 3
    }
}
