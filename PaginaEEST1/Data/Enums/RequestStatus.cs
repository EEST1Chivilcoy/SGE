using System.ComponentModel.DataAnnotations;

namespace PaginaEEST1.Data.Enums
{
    public enum RequestStatus
    {
        [Display(Name = "Pendiente")]
        Pendiente,  // La solicitud ha sido creada pero no atendida
        [Display(Name = "En Proceso")]
        EnProceso,  // La solicitud está en proceso de resolución
        [Display(Name = "Completada")]
        Completada  // La solicitud ha sido completada
    }
}
