using Microsoft.Identity.Client;
using PaginaEEST1.Data.Models.Personal;

using System.ComponentModel.DataAnnotations.Schema;

namespace PaginaEEST1.Data.Models.Objetos_Fisicos
{
    public class Netbook : DispositivoComputacional
    {
        public string? Modelo { get; set; }

        public bool Prestamo { get; set; }
    }
}
