using Microsoft.Identity.Client;
using PaginaEEST1.Data.Models.Personal;

using System.ComponentModel.DataAnnotations.Schema;

namespace PaginaEEST1.Data.Models.PhysicalObjects
{
    public class Desktop : Computer
    {
        public string? Location { get; set; }
    }
}
