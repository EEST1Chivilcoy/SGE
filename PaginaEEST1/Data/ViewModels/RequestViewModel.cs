using PaginaEEST1.Data.Enums;

namespace PaginaEEST1.Data.ViewModels
{
    public class RequestViewModel
    {
        public int ID { get; set; }
        public TypeRequest Type { get; set; }
        public string? ShortDescription { get; set; }
        public DateTime RequestDate { get; set; } 
        public RequestStatus Status { get; set; }
        public string? ProfessorId { get; set; }
    }
}
