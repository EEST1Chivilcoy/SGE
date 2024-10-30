namespace PaginaEEST1.Data.Models.PhysicalObjects
{
    public class ConsumableItem : Item
    {
        // Los consumibles no requieren devolución
        public override bool RequiresReturn => false;
    }
}
