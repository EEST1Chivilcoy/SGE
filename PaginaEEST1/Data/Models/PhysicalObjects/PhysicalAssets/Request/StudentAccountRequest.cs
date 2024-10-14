using System.ComponentModel.DataAnnotations;

namespace PaginaEEST1.Data.Models.PhysicalObjects.PhysicalAssets.Request
{
    public class StudentAccountRequest : Request
    {
        public string? StudentName { get; set; } = null!;
        public string? StudentSurname { get; set; } = null!;
        public string? StudentEmail { get; set; } = null!;
        public string? StudentCellPhoneNumber = null!;
        public string? SchoolYear { get; set; } = null!;
        public string? SchoolDivision { get; set; } = null!;


    }
}
