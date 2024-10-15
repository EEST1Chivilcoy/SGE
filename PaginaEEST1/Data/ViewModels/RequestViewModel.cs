using PaginaEEST1.Data.Enums;

namespace PaginaEEST1.Data.ViewModels
{
    public class RequestViewModel
    {
        public int ID { get; set; }
        public TypeRequest Type { get; set; }
        public int ComputerId { get; set; }
        public int ProfessorId { get; set; }
        public string? ShortDescription { get; set; }
        public DateTime RequestDate { get; set; } 
        public DateTime? RequestStartDate { get; set; }
        public DateTime? EstimatedCompletionDate { get; set; }
        public RequestStatus Status { get; set; }
        // Detalles específicos de la instalación
        public string? NameProgram { get; set; }
        public string? VersionProgram { get; set; }
        // Detalles específicos del fallo
        public string? FailureDescription { get; set; }
        public FailurePreority Preority { get; set; }
        // Detalles específicos de la cuenta
        public string? StudentName { get; set; }
        public string? StudentSurname { get; set; }
        public string? StudentEmail { get; set; }
        public string? StudentCellPhoneNumber { get; set; }
        public string? SchoolYear { get; set; }
        public string? SchoolDivision { get; set; }
    }
}
