using System.ComponentModel.DataAnnotations;

namespace PaginaEEST1.Data.Enums
{
    public enum TypeItem
    {
        [Display(Name = "Retornable")]
        ReturnableItem = 1,
        [Display(Name = "Consumible")]
        ConsumableItem = 2
    }
}
