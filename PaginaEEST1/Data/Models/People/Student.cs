using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using PaginaEEST1.Data.Enums;

namespace PaginaEEST1.Data.Models.Personal
{
    public class Student : Person
    {
        public TypeShifts Shift { get; set; }
    }
}
