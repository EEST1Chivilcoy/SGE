using Microsoft.Identity.Client;
using PaginaEEST1.Data.Models.Personal;

using System.ComponentModel.DataAnnotations.Schema;

namespace PaginaEEST1.Data.Models.PhysicalObjects
{
    public class Netbook : Computer
    {
        public string? Model { get; set; }
        public bool IsAvailable { get; set; }
    }
}
