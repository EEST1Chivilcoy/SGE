using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations;
using PaginaEEST1.Data.Enums;

namespace PaginaEEST1.Data.Models.PhysicalObjects
{
    public class ComputerMonitor
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Brand { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string Model { get; set; } = null!;

        [Required]
        [Range(10, 100)]
        public int SizeInInches { get; set; }

        [Required]
        public Resolutions Resolution { get; set; }

        [Required]
        public List<MonitorConnectionType> ConnectionTypes { get; set; } = new List<MonitorConnectionType>();
        [Required] 
        public AspectRatio AspectRatio { get; set; }
    }
}
