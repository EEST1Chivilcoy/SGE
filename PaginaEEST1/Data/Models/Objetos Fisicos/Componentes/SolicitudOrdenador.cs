using PaginaEEST1.Data.Models.Personal;
using System.ComponentModel.DataAnnotations.Schema;
using PaginaEEST1.Data.Enums;


namespace PaginaEEST1.Data.Models.Objetos_Fisicos.Componentes
{
    public abstract class SolicitudOrdenador
    {
        //Datos Importantes
        public int Id { get; set; }  // ID único para la solicitud
        public TipoSolicitud Tipo { get; set; }  // Tipo de la solicitud (Instalación o Reporte de fallo)
        //Relaciones [Profesor - Ordenador]
        public int OrdenadorId { get; set; }
        [ForeignKey(nameof(OrdenadorId))]
        public DispositivoComputacional ordenador { get; set; } = null!;
        public int ProfesorId { get; set; }
        [ForeignKey(nameof(ProfesorId))]
        public Profesor ProfesorSolicitante { get; set; } = null!;
        //Otros Datos
        public string DescripcionCorta { get; set; } = null!;  // Descripción corta de la solicitud
        
        public DateTime FechaSolicitud { get; set; }  // Fecha en que se realiza la solicitud
        public DateTime? FechaFinalizacionEstimada { get; set; } //Fecha estimada de finalización
        public EstadoSolicitud Estado { get; set; }  // Estado de la solicitud (Pendiente, En proceso, Completada)
    }
}
