using Microsoft.Identity.Client;
using PaginaEEST1.Data.Models.Personal;
using PaginaEEST1.Data.Models.SchoolArea;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaginaEEST1.Data.Models.PhysicalObjects
{
    public class Desktop : Computer
    {
        public int LocationId { get; set; }
        [ForeignKey(nameof(LocationId))]
        public Area? Location { get; set; }
    }
}
