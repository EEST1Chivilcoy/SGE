using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PaginaEEST1.Data.Models.Personal;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaginaEEST1.Data.Models.Objetos_Fisicos.Componentes
{
    public class ReservaNetbook
    {
        public int Id { get; set; }
        public string? Materia { get; set; }
        //Relacion con Profesor (Obligatoria)
        public int ProfesorId { get; set; }
        [ForeignKey(nameof(ProfesorId))]
        public Profesor profesor { get; set;}
        // Relacion con Alumno (No Obligatoria)
        public int? AlumnoId { get; set; }
        [ForeignKey(nameof(AlumnoId))]
        public Alumno? alumno { get; set; }
    }
}
