using PaginaEEST1.Data.Models.PhysicalObjects.PhysicalAssets.Loan;

namespace PaginaEEST1.Data.Models.PhysicalObjects
{
    public class ReturnableItem : Item
    {
        // Los artículos retornables requieren devolución
        public override bool RequiresReturn => true;
        public List<ItemLoan>? Loans { get; set; }
    }
}
