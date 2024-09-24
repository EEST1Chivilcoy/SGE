using PaginaEEST1.Data.Enums;

namespace PaginaEEST1.Data.Models.Objetos_Fisicos
{
    public abstract class Computer
    {
        public int Id { get; set; }
        public string? DeviceName { get; set; }
        public TypeComputer Type { get; set; }

        // Datos
        public ComputerStatus Status { get; set; }

        // Datos no obligatorios
        public string? OperatingSystem { get; set; }
        public string? Processor { get; set; }
        public int? RAM { get; set; }
        public int? Storage { get; set; }
        public TypeStorage typeStorage { get; set; }
    }
}
