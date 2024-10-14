using PaginaEEST1.Data.Models.Objetos_Fisicos;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaginaEEST1.Data.Models.PhysicalObjects.PhysicalAssets.Request
{
    public abstract class RequestComputer : Request
    {
        //Relaciones [Profesor - Ordenador]
        public int ComputerId { get; set; }
        [ForeignKey(nameof(ComputerId))]
        public Computer Computer { get; set; } = null!;

        /* ! Temporalmente deshabilitado para implementarlo correctamente en una futura actualización
        public int ProfessorId { get; set; }
        [ForeignKey(nameof(ProfessorId))]
        public Professor RequestingProfessor { get; set; }
        */
    }
}
