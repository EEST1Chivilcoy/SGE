using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PaginaEEST1.Data.Models.Personal;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaginaEEST1.Data.Models.Objetos_Fisicos.Componentes
{
    public class NetbookLoan
    {
        public int Id { get; set; }
        public string? Subject { get; set; }
        //Relacion Con Netbooks (Obligatoria)
        public List<Netbook> Netbooks { get; set; } = null!;
        //Relacion con Profesor (Obligatoria)
        public int ProfessorId { get; set; }
        [ForeignKey(nameof(ProfessorId))]
        public Professor Professor { get; set; } = null!;
        // Relacion con Alumno (No Obligatoria)
        public int? StudentId { get; set; }
        [ForeignKey(nameof(StudentId))]
        public Student? Student { get; set; }
    }
}
