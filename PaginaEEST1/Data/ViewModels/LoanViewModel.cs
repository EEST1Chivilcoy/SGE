using PaginaEEST1.Data.Enums;
using PaginaEEST1.Data.Models.Personal;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaginaEEST1.Data.ViewModels
{
    public class LoanViewModel
    {
        public int Id { get; set; }
        public TypeLoan Type { get; set; }
        public LoanStatus Status { get; set; }
        public DateOnly RequiredDate { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly FinishTime { get; set; }
        public string? SchoolGrade { get; set; }
        public string Professor { get; set; } = null!;
        public List<string?> Assets { get; set; } = new();
    }
}
