using PaginaEEST1.Data.Enums;

namespace PaginaEEST1.Data.ViewModels
{
    public class ComputadoraVM
    {
        public EstadoOrdenador Estado { get; set; }
        public string? NombreOrdenador { get; set; }
        public string? SistemaOperativo { get; set; }
        public string? Procesador { get; set; }
        public int? RAM { get; set; }
        public int? Almacenamiento { get; set; }
        public string? Ubicacion { get; set; }
    }
}
