using PaginaEEST1.Data.Enums;

namespace PaginaEEST1.Data.ViewModels
{
    public class ComputerViewModel
    {
        public int ID { get; set; }
        public TypeComputer Type {get; set;}
        public ComputerStatus Status { get; set; }
        public string? DeviceName { get; set; }
        public string? OperatingSystem { get; set; }
        public string? Logo {get; set;}
    }
}
