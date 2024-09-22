using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using PaginaEEST1.Data.Enums;
using PaginaEEST1.Data.Models.Objetos_Fisicos;

namespace PaginaEEST1.Data.Models.Personal
{
    public class Profesor : Persona
    {
        [StringLength(255)]
        public string? Titulo { get; set; }
        [StringLength(255)]
        public NivelDeEstudio NivelEstudios { get; set; }
    }
}
