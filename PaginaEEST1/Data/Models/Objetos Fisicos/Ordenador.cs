using PaginaEEST1.Data.Enums;

namespace PaginaEEST1.Data.Models.Objetos_Fisicos
{
    public abstract class Ordenador
    {
        public int OrdenadorId { get; set; }
        public string? NombreOrdenador { get; set; }
        public TipoOrdenador TipoOrdenador { get; set; }

        // Datos
        public EstadoOrdenador Estado { get; set; }

        // Datos no obligatorios
        public string? SistemaOperativo { get; set; }
        public string? Procesador { get; set; }
        public int? RAM { get; set; }
        public int? Almacenamiento { get; set; }
        public TipoAlmacenamiento tipoAlmacenamiento { get; set; }

        /* Para consultar, posibles:
         
        public DateTime FechaAdquisicion { get; set; }

        public int IP { get; set; }

        public int IP_Mac { get; set; }

        */
    }
}
