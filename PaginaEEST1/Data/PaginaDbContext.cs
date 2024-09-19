using Microsoft.EntityFrameworkCore;
using PaginaEEST1.Data.Enums;
using PaginaEEST1.Data.Models.Objetos_Fisicos;
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
        //Computadoras
        public DbSet<Computadora> Computadoras { get; set; }
        public DbSet<Netbook> Netbooks { get; set; }
        // Personas
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Directivo> Directivos { get; set; }
        public DbSet<EMATP> EMATP { get; set; }
        public DbSet<Paniol> Paniol { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }

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
            .Entity<Profesor>()
                .Property(p => p.NivelEstudios)
                .HasConversion<string>()
                .HasMaxLength(255);

            modelBuilder
            .Entity<Alumno>()
                .Property(p => p.Turno_Cursada)
                .HasConversion<string>()
                .HasMaxLength(255);

            // Discriminadores
            /*
            modelBuilder
                .Entity<Persona>()
                .HasDiscriminator<int>(nameof(Persona.TipoPersona))
                .HasValue<Directivo>(TipoPersona.Directivo)
                .HasValue<EMATP>(TipoPersona.EMATP)
                .HasValue<Paniol>(TipoPersona.Paniol)
                .HasValue<Profesor>(TipoPersona.Profesor)
                .HasValue<Alumno>(TipoPersona.Alumno);

            modelBuilder
                .Entity<Computadora>()
                .HasDiscriminator<TipoComputadora>(nameof(Computadora.TipoComputadora))
                .HasValue<Computadora>(TipoComputadora.Computadora)
                .HasValue<Netbook>(TipoComputadora.Netbook);
            */

            // Llaves Foraneas

            modelBuilder
                .Entity<Netbook>()
                .HasOne(i => i.Profesor)
                .WithOne(v => v.Netbook)
                .HasForeignKey<Netbook>(i => i.ProfesorId)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false);

            modelBuilder
                .Entity<Netbook>()
                .HasOne(i => i.Alumno)
                .WithOne(v => v.Netbook)
                .HasForeignKey<Netbook>(i => i.AlumnoId)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false);

        }
    }
}
