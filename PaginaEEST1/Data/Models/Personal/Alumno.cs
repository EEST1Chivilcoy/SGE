using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using PaginaEEST1.Data.Enums;
using PaginaEEST1.Data.Models.Objetos_Fisicos;

namespace PaginaEEST1.Data.Models.Personal
{
    public class Alumno : Persona
    {
        public Turno Turno_Cursada { get; set; }

        // Llaves Foraneas
        public Netbook? Netbook { get; set; }
    }
}
