using Microsoft.EntityFrameworkCore;
using PaginaEEST1.Data.Models.Personal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaginaEEST1.Data
{
    public class PaginaDbContext : DbContext
    {
        public DbSet<Persona> Personas { get; set; }

        public PaginaDbContext(DbContextOptions<PaginaDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Enums
            modelBuilder
            .Entity<Persona>()
                .Property(p => p.Sexo)
                .HasConversion<string>()
                .HasMaxLength(255);

            modelBuilder
            .Entity<Persona>()
                .Property(p => p.NivelEstudios)
                .HasConversion<string>()
                .HasMaxLength(255);
        }
    }
}
