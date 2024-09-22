using PaginaEEST1.Data.Enums;

namespace PaginaEEST1.Data.Models.Objetos_Fisicos.Componentes
{
    public class SolicitudFallo : SolicitudOrdenador
    {
        public string DescripcionFallo { get; set; } = null!;  // Descripción del fallo en el PC (solo para reporte de fallo)
        public PrioridadFallo Prioridad { get; set; }  // Prioridad del fallo (Baja, Media, Alta)
    }
}
