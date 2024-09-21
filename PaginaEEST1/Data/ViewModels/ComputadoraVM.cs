using PaginaEEST1.Data.Enums;

namespace PaginaEEST1.Data.ViewModels
{
    public class ComputadoraVM
    {
        public Estado_Ordenador Estado { get; set; }
        public string? Nombre { get; set; }
        public string? Sistema_Operativo { get; set; }
        public string? Procesador { get; set; }
        public int? RAM { get; set; }
        public int? Almacenamiento { get; set; }
        public string? Ubicacion { get; set; }
    }
}
