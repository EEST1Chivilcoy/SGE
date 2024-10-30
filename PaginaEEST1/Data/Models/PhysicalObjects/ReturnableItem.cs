namespace PaginaEEST1.Data.Models.PhysicalObjects
{
    public class ReturnableItem : Item
    {
        // Los artículos retornables requieren devolución
        public override bool RequiresReturn => true;
    }
}
