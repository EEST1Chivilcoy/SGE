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
        public string? Processor { get; set; }
        public int? RAM { get; set; }
        public int? Storage { get; set; }
        public TypeStorage StorageType { get; set; }
        public string? Logo {get; set;}
        public string? Location { get; set; }
        public string? Model { get; set; }
        public bool IsAvailable { get; set; }
    }
}
