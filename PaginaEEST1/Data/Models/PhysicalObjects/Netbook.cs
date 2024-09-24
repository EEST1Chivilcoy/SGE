using Microsoft.Identity.Client;
using PaginaEEST1.Data.Models.Personal;

using System.ComponentModel.DataAnnotations.Schema;

namespace PaginaEEST1.Data.Models.Objetos_Fisicos
{
    public class Netbook : Computer
    {
        public string? Model { get; set; }
        public bool IsAvailable { get; set; }
    }
}
