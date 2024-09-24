namespace PaginaEEST1.Data.Models.Objetos_Fisicos.Componentes
{
    public class InstallationRequest : RequestComputer
    {
        // Detalles específicos de la instalación
        public string NameProgram { get; set; } = null!;  // Nombre del programa a instalar
        public string? VersionProgram { get; set; }  // Versión del programa a instalar (opcional)
    }
}
