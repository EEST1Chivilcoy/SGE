namespace PaginaEEST1.Data.Models.People.PeopleAssets
{
    public class Attendance
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<AttendanceRecord> Records { get; set; } = new List<AttendanceRecord>();
    }
}
