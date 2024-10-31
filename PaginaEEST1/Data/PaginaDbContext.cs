using Microsoft.EntityFrameworkCore;
using PaginaEEST1.Data.Enums;
using PaginaEEST1.Data.Models.PhysicalObjects;
using PaginaEEST1.Data.Models.PhysicalObjects.Componentes;
using PaginaEEST1.Data.Models.People.PeopleAssets;
using PaginaEEST1.Data.Models.Personal;
using PaginaEEST1.Data.Models.PhysicalObjects.PhysicalAssets.Request;
using PaginaEEST1.Data.Models.PhysicalObjects.PhysicalAssets.Loan;
using PaginaEEST1.Data.Models.SchoolArea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaginaEEST1.Data.Models.Categories;
using PaginaEEST1.Data.Models.Images;

namespace PaginaEEST1.Data
{
    public class PaginaDbContext : DbContext
    {
        // Tablas (Entidades)
        public DbSet<Computer> Computers { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<AbstractImage> Images { get; set; }

        // Tablas (Reportes / Planillas)
        public DbSet<Loan> Loans { get; set; }
        public DbSet<RequestEMATP> ComputerRequests { get; set; }

        // Tablas Asistencia
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<AttendanceRecord> AttendanceRecords { get; set; }

        // Tabla de Categorias
        public DbSet<Category> Categories { get; set; }

        public PaginaDbContext(DbContextOptions<PaginaDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Foreaneas 1:1
            modelBuilder.Entity<Person>()
                .HasOne(p => p.ProfileImage)
                .WithOne(pi => pi.Person)
                .HasForeignKey<ProfileImage_Person>(pi => pi.PersonId); // Clave foránea en ProfileImage

            modelBuilder.Entity<Area>()
                .HasOne(a => a.ImageArea)
                .WithOne(ai => ai.Area)
                .HasForeignKey<AreaImage_Area>(ai => ai.AreaId); // Clave foránea en AreaImage

            modelBuilder.Entity<Item>()
                .HasOne(i => i.ItemImage)
                .WithOne(ii => ii.Item)
                .HasForeignKey<ItemImage_Item>(ii => ii.ItemId); // Clave foránea en ItemImage

            // Enums

            modelBuilder
            .Entity<AttendanceRecord>()
                .Property(a => a.Type)
                .HasConversion<string>()
                .HasMaxLength(255);

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

            modelBuilder
            .Entity<Area>()
                .Property(a => a.AreaType)
                .HasConversion<string>()
                .HasMaxLength(255);

            modelBuilder
            .Entity<Item>()
                .Property(i => i.Owner)
                .HasConversion<int>();

            //Enums Discriminadores

            modelBuilder.Entity<Person>()
                .Property(p => p.TypePerson)
                .HasConversion<int>();

            modelBuilder.Entity<Computer>()
                .Property(c => c.Type)
                .HasConversion<int>();

            modelBuilder.Entity<RequestEMATP>()
                .Property(s => s.Type)
                .HasConversion<int>();

            modelBuilder.Entity<Loan>()
                .Property(l => l.Type)
                .HasConversion<int>();

            modelBuilder.Entity<Category>()
                .Property(c => c.Type)
                .HasConversion<int>();

            modelBuilder.Entity<Item>()
                .Property(i => i.Type)
                .HasConversion<int>();

            modelBuilder.Entity<AbstractImage>()
                .Property(a => a.ImageType)
                .HasConversion<int>();

            // Unique

            modelBuilder.Entity<Computer>()
                .HasIndex(o => o.DeviceName)
                .IsUnique();

            modelBuilder.Entity<Item>()
                .HasIndex(i => i.Code)
                .IsUnique();

            // Discriminadores

            modelBuilder.Entity<Person>()
                .HasDiscriminator(p => p.TypePerson)
                .HasValue<SchoolPrincipal>(TypePerson.SchoolDirector)
                .HasValue<EMATP>(TypePerson.EMATP)
                .HasValue<Storeroom>(TypePerson.Warehouse)
                .HasValue<Professor>(TypePerson.Teacher)
                .HasValue<Student>(TypePerson.Student);

            modelBuilder
                .Entity<Computer>()
                .HasDiscriminator(c => c.Type)
                .HasValue<Desktop>(TypeComputer.Computer)
                .HasValue<Netbook>(TypeComputer.Netbook);

            modelBuilder
                .Entity<RequestEMATP>()
                .HasDiscriminator(s => s.Type)
                .HasValue<InstallationRequest>(TypeRequest.Instalacion)
                .HasValue<FailureRequest>(TypeRequest.ReporteFallo)
                .HasValue<StudentAccountRequest>(TypeRequest.SolicitudCuenta);

            modelBuilder
                .Entity<Loan>()
                .HasDiscriminator(l => l.Type)
                .HasValue<NetbookLoan>(TypeLoan.NetbookLoan);

            modelBuilder
                .Entity<Category>()
                .HasDiscriminator(c => c.Type)
                .HasValue<AreaCategory>(TypeCategory.AreaCategory)
                .HasValue<ItemCategory>(TypeCategory.ItemCategory);

            modelBuilder
                .Entity<Item>()
                .HasDiscriminator(i => i.Type)
                .HasValue<ReturnableItem>(TypeItem.ReturnableItem)
                .HasValue<ConsumableItem>(TypeItem.ConsumableItem);

            modelBuilder
                .Entity<AbstractImage>()
                .HasDiscriminator(ai => ai.ImageType)
                .HasValue<AreaImage_Area>(TypeImage.AreaImage)
                .HasValue<ItemImage_Item>(TypeImage.ItemImage)
                .HasValue<ProfileImage_Person>(TypeImage.ProfileImage);
        }
    }
}
