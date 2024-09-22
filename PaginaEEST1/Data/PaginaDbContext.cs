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
        // Tablas
        public DbSet<Ordenador> Ordenadores  { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<ReservaNetbook> ReservasDeNetbooks { get; set; }

        public PaginaDbContext(DbContextOptions<PaginaDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Enums
            modelBuilder
            .Entity<Ordenador>()
                .Property(o => o.tipoAlmacenamiento)
                .HasConversion<string>()
                .HasMaxLength(255);

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

            //Enums Discriminadores

            modelBuilder.Entity<Persona>()
                .Property(p => p.TipoPersona)
                .HasConversion<int>();

            modelBuilder.Entity<Ordenador>()
                .Property(c => c.TipoOrdenador)
                .HasConversion<int>();

            // Discriminadores

            modelBuilder.Entity<Persona>()
                .HasDiscriminator(p => p.TipoPersona)
                .HasValue<Directivo>(TipoPersona.Directivo)
                .HasValue<EMATP>(TipoPersona.EMATP)
                .HasValue<Paniol>(TipoPersona.Paniol)
                .HasValue<Profesor>(TipoPersona.Profesor)
                .HasValue<Alumno>(TipoPersona.Alumno);

            modelBuilder
                .Entity<Ordenador>()
                .HasDiscriminator(c => c.TipoOrdenador)
                .HasValue<Computadora>(TipoOrdenador.Computadora)
                .HasValue<Netbook>(TipoOrdenador.Netbook);

        }
    }
}
