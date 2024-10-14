using System.ComponentModel.DataAnnotations;

namespace PaginaEEST1.Data.Enums
{
    public enum TypeRequest //Pasar a Ingles (Pronto)
    {
        [Display(Name = "Instalación de un Programa")]
        Instalacion = 1,  // Instalación de programa (ProgramInstallation)
        [Display(Name = "Reporte de Fallos")]
        ReporteFallo = 2, // Reporte de fallo en el PC (PCFailure)
        [Display(Name = "Solicitud de Cuenta Estudiantil")]
        SolicitudCuenta = 3 // Solicitud de Cuenta para el Estudiante, esta posee ciertos beneficios (StudentAccount)
    }
}
