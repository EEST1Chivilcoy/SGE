using PaginaEEST1.Data.Enums;

namespace PaginaEEST1.Data.Models.People.PeopleAssets
{
    public class AttendanceRecord
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public AttendanceType Type { get; set; }
    }
}
