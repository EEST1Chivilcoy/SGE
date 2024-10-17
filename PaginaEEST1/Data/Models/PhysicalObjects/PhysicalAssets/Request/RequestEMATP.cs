using PaginaEEST1.Data.Models.Personal;
using System.ComponentModel.DataAnnotations.Schema;
using PaginaEEST1.Data.Enums;
using PaginaEEST1.Data.Models.Objetos_Fisicos;

namespace PaginaEEST1.Data.Models.PhysicalObjects.PhysicalAssets.Request
{
    public abstract class RequestEMATP
    {
        //Datos Importantes
        public int Id { get; set; }  // ID único para la solicitud
        public TypeRequest Type { get; set; }  // Tipo de la solicitud (Instalación o Reporte de fallo o Pedido de Cuenta Estudiantil)


        //Otros Datos
        public string? ShortDescription { get; set; }  // Descripción corta de la solicitud
        public DateTime RequestDate { get; set; }  // Fecha en que se realiza la solicitud
        public DateTime? RequestStartDate { get; set; } // Fecha en la que se empezo a trabajar en la solicitud
        public DateTime? EstimatedCompletionDate { get; set; } //Fecha estimada de finalización
        public RequestStatus Status { get; set; }  // Estado de la solicitud (Pendiente, En proceso, Completada)
    }
}
