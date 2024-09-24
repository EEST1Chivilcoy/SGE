using PaginaEEST1.Data.Enums;

namespace PaginaEEST1.Data.ViewModels
{
    public class DesktopViewModel
    {
        public int ID { get; set; }
        public ComputerStatus Status { get; set; }
        public string? DeviceName { get; set; }
        public string? OperatingSystem { get; set; }
        public string? Processor { get; set; }
        public int? RAM { get; set; }
        public int? Storage { get; set; }
        public string? Location { get; set; }
        public TypeStorage StorageType { get; set; }
        public string Logo_PC = "Images/Desktop_PC.png";
    }
}
