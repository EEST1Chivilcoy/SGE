using PaginaEEST1.Data.Enums;
using PaginaEEST1.Data.Models.Personal;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaginaEEST1.Data.Models.PhysicalObjects.PhysicalAssets.Loan
{
    public abstract class Loan
    {
        public int Id { get; set; }
        public TypeLoan Type { get; set; }

        /// <summary>
        /// FK de Relacion con Profesor (Obligatoria)
        /// </summary>
        public string ProfessorId { get; set; } = null!;
        [ForeignKey(nameof(ProfessorId))]

        /// <summary>
        /// Relacion con Profesor (Obligatoria)
        /// </summary>
        public Professor Professor { get; set; } = null!;

        /// <summary>
        /// FK de Relacion con Alumno (No Obligatoria)
        /// </summary>
        public string? StudentId { get; set; }
        [ForeignKey(nameof(StudentId))]

        /// <summary>
        /// Relacion con Alumno (No Obligatoria)
        /// </summary>
        public Student? Student { get; set; }
    }
}
