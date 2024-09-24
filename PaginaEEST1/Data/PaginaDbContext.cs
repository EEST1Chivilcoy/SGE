using Microsoft.EntityFrameworkCore;
using PaginaEEST1.Data.Enums;
using PaginaEEST1.Data.Models.Objetos_Fisicos;
using PaginaEEST1.Data.Models.Objetos_Fisicos.Componentes;
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
        // Tablas (Entidades)
        public DbSet<Computer> Computers  { get; set; }
        public DbSet<Person> People { get; set; }

        // Tablas (Reportes / Planillas)
        public DbSet<NetbookLoan> ReservasDeNetbooks { get; set; }
        public DbSet<RequestComputer> SolicitudesOrdenador { get; set; }

        public PaginaDbContext(DbContextOptions<PaginaDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Enums
            modelBuilder
            .Entity<Computer>()
                .Property(o => o.typeStorage)
                .HasConversion<string>()
                .HasMaxLength(255);

            modelBuilder
            .Entity<Person>()
                .Property(p => p.Gender)
                .HasConversion<string>()
                .HasMaxLength(255);

            modelBuilder
            .Entity<Professor>()
                .Property(p => p.EducationLevel)
                .HasConversion<string>()
                .HasMaxLength(255);

            modelBuilder
            .Entity<Student>()
                .Property(p => p.Shift)
                .HasConversion<string>()
                .HasMaxLength(255);

            //Enums Discriminadores

            modelBuilder.Entity<Person>()
                .Property(p => p.TypePerson)
                .HasConversion<int>();

            modelBuilder.Entity<Computer>()
                .Property(c => c.typeComputer)
                .HasConversion<int>();

            modelBuilder.Entity<RequestComputer>()
                .Property(s => s.Type)
                .HasConversion<int>();

            // Unique

            modelBuilder.Entity<Computer>()
                .HasIndex(o => o.DeviceName)
                .IsUnique();

            // Discriminadores

            modelBuilder.Entity<Person>()
                .HasDiscriminator(p => p.TypePerson)
                .HasValue<SchoolPrincipal>(TypePerson.Directivo)
                .HasValue<EMATP>(TypePerson.EMATP)
                .HasValue<Storeroom>(TypePerson.Paniol)
                .HasValue<Professor>(TypePerson.Profesor)
                .HasValue<Student>(TypePerson.Alumno);

            modelBuilder
                .Entity<Computer>()
                .HasDiscriminator(c => c.typeComputer)
                .HasValue<Desktop>(TypeComputer.Computadora)
                .HasValue<Netbook>(TypeComputer.Netbook);

            modelBuilder
                .Entity<RequestComputer>()
                .HasDiscriminator(s => s.Type)
                .HasValue<SolicitudInstalacion>(TypeRequest.Instalacion)
                .HasValue<SolicitudFallo>(TypeRequest.ReporteFallo);
        }
    }
}
