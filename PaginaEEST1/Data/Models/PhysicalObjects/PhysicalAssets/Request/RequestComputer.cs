using PaginaEEST1.Data.Models.Personal;
using PaginaEEST1.Data.Models.PhysicalObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaginaEEST1.Data.Models.PhysicalObjects.PhysicalAssets.Request
{
    public abstract class RequestComputer : RequestEMATP
    {
        //Relaciones [Profesor - Ordenador]
        /// <summary>
        /// FK de Relacion con Computer (Obligatoria)
        /// </summary>
        public int ComputerId { get; set; }
        [ForeignKey(nameof(ComputerId))]
        /// <summary>
        /// Relacion con Computer (Obligatoria)
        /// </summary>
        public Computer Computer { get; set; } = null!;
        /// <summary>
        /// FK de Relacion con Profesor (Obligatoria)
        /// </summary>
        public string? ProfessorId { get; set; }
        [ForeignKey(nameof(ProfessorId))]

        /// <summary>
        /// Relacion con Profesor (Obligatoria)
        /// </summary>
        public Professor Professor { get; set; } = null!;
    }
}
