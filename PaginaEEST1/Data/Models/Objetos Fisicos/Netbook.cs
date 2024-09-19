using Microsoft.Identity.Client;
using PaginaEEST1.Data.Models.Personal;

using System.ComponentModel.DataAnnotations.Schema;

namespace PaginaEEST1.Data.Models.Objetos_Fisicos
{
    public class Netbook : Computadora
    {
        // Llaves Foraneas
        public int? ProfesorId { get; set; }
        [ForeignKey(nameof(ProfesorId))]
        public Profesor? Profesor { get; set; }
        public int? AlumnoId { get; set; }
        [ForeignKey(nameof(AlumnoId))]
        public Alumno? Alumno { get; set; }
    }
}
