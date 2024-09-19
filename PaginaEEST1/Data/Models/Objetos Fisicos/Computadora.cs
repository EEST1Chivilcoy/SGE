using PaginaEEST1.Data.Enums;

namespace PaginaEEST1.Data.Models.Objetos_Fisicos
{
    public class Computadora
    {
        public int ComputadoraId { get; set; }
        public TipoComputadora TipoComputadora { get; set; }
        public string? Nombre { get; set; }
        public string? Estado { get; set; }
        public string? SistemaOperativo { get; set; }
        public DateTime FechaAdquisicion { get; set; }
        public string? Ubicacion { get; set; }
    }
}
