using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PaginaEEST1.Data.Models.Personal;
using PaginaEEST1.Data.Models.PhysicalObjects.PhysicalAssets.Loan;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaginaEEST1.Data.Models.PhysicalObjects.PhysicalAssets.Loan
{
    public class ItemLoan: Loan
    {
        /// <summary>
        /// Relacion Con Objetos Retornables (Obligatorio)
        /// </summary>
        public List<ReturnableItem> Items { get; set; } = null!;
    }
}
