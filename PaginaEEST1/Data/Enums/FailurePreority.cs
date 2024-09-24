using System.ComponentModel.DataAnnotations;

namespace PaginaEEST1.Data.Enums
{
    public enum FailurePreority
    {
        [Display(Name = "Fallo menor")]
        Baja,   // Fallo menor, no urgente
        [Display(Name = "Fallo de importancia media")]
        Media,  // Fallo de importancia media
        [Display(Name = "Fallo crítico")]
        Alta    // Fallo crítico, requiere atención inmediata
    }
}
