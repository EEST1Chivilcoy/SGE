using PaginaEEST1.Data.Models.Personal;
using System.ComponentModel.DataAnnotations.Schema;
using PaginaEEST1.Data.Enums;


namespace PaginaEEST1.Data.Models.Objetos_Fisicos.Componentes
{
    public abstract class RequestComputer
    {
        //Datos Importantes
        public int Id { get; set; }  // ID único para la solicitud
        public TypeRequest Type { get; set; }  // Tipo de la solicitud (Instalación o Reporte de fallo)
        //Relaciones [Profesor - Ordenador]
        public int ComputerId { get; set; }
        [ForeignKey(nameof(ComputerId))]
        public Computer Computer { get; set; } = null!;
        /* ! Temporalmente deshabilitado para implementarlo correctamente en una futura actualización
        public int ProfessorId { get; set; }
        [ForeignKey(nameof(ProfessorId))]
        public Professor RequestingProfessor { get; set; }
        */
        //Otros Datos
        public string ShortDescription { get; set; } = null!;  // Descripción corta de la solicitud
        public DateTime RequestDate { get; set; }  // Fecha en que se realiza la solicitud
        public DateTime? RequestStartDate { get; set; }
        public DateTime? EstimatedCompletionDate { get; set; } //Fecha estimada de finalización
        public RequestStatus Status { get; set; }  // Estado de la solicitud (Pendiente, En proceso, Completada)
    }
}
