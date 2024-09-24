using PaginaEEST1.Data.Enums;

namespace PaginaEEST1.Data.Models.Objetos_Fisicos.Componentes
{
    public class SolicitudFallo : RequestComputer
    {
        public string FailureDescription { get; set; } = null!;  // Descripción del fallo en el PC (solo para reporte de fallo)
        public FailurePreority Preority { get; set; }  // Prioridad del fallo (Baja, Media, Alta)
    }
}
