using PaginaEEST1.Data.Models.PhysicalObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaginaEEST1.Data.Models.PhysicalObjects.PhysicalAssets.Request
{
    public abstract class RequestComputer : RequestEMATP
    {
        //Relaciones [Profesor - Ordenador]
        public int ComputerId { get; set; }
        [ForeignKey(nameof(ComputerId))]
        public Computer Computer { get; set; } = null!;
    }
}
