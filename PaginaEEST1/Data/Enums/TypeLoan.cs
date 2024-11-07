using System.ComponentModel.DataAnnotations;

namespace PaginaEEST1.Data.Enums
{
    public enum TypeLoan
    {
        [Display(Name = "Prestamo de Netbooks")]
        NetbookLoan = 1,
        [Display(Name = "Prestamo de Objetos Retornables")]
        ItemLoan = 2
    }
}
