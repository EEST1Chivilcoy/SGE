using Microsoft.Identity.Client;
using PaginaEEST1.Data.Models.Personal;
using PaginaEEST1.Data.Models.PhysicalObjects.PhysicalAssets.Loan;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaginaEEST1.Data.Models.PhysicalObjects
{
    public class Netbook : Computer
    {
        public string? Model { get; set; }
        public bool IsAvailable { get; set; }
        public List<NetbookLoan>? Loans { get; set; }
    }
}
