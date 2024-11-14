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
        /// Estado en el que se encuentra la solicitud
        /// </summary>
        public LoanStatus Status { get; set; }
        /// <summary>
        /// Fecha en la que se solocitó el prestamo
        /// </summary>
        public DateTime SubmitDate { get; set; }

        /// <summary>
        /// Fecha requerida el prestamo
        /// </summary>
        public DateOnly RequiredDate { get; set; }

        /// <summary>
        /// Hora de inicio del prestamo
        /// </summary>
        public TimeOnly StartTime { get; set; }

        /// <summary>
        /// Hora de finalización y entrega del prestamo
        /// </summary>
        public TimeOnly FinishTime { get; set; }

        /// <summary>
        /// Grado y División del curso en el que se solicita el prestamo
        /// </summary>
        public string? SchoolGrade { get; set; }

        /// <summary>
        /// FK de Relacion con Profesor (Obligatoria)
        /// </summary>
        public string ProfessorId { get; set; } = null!;
        [ForeignKey(nameof(ProfessorId))]

        /// <summary>
        /// Relacion con Profesor (Obligatoria)
        /// </summary>
        public Professor Professor { get; set; } = null!;
    }
}
