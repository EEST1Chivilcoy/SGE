namespace PaginaEEST1.Data.Models.Objetos_Fisicos.Componentes
{
    public class SolicitudInstalacion : SolicitudOrdenador
    {
        // Detalles específicos de la instalación
        public string NombrePrograma { get; set; } = null!;  // Nombre del programa a instalar
        public string? VersionPrograma { get; set; }  // Versión del programa a instalar (opcional)
    }
}
