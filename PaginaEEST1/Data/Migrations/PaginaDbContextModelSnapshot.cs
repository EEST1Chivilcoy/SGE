﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PaginaEEST1.Data;

#nullable disable

namespace PaginaEEST1.Data.Migrations
{
    [DbContext(typeof(PaginaDbContext))]
    partial class PaginaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("PaginaEEST1.Data.Models.Categories.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasDiscriminator<int>("Type");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.People.PeopleAssets.Attendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ProfessorPersonId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("ProfessorPersonId");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.People.PeopleAssets.AttendanceRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AttendanceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("AttendanceId");

                    b.ToTable("AttendanceRecords");
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.Personal.Person", b =>
                {
                    b.Property<string>("PersonId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("TypePerson")
                        .HasColumnType("int");

                    b.HasKey("PersonId");

                    b.ToTable("People");

                    b.HasDiscriminator<int>("TypePerson");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.PhysicalObjects.Computer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DeviceName")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("OperatingSystem")
                        .HasColumnType("longtext");

                    b.Property<string>("Processor")
                        .HasColumnType("longtext");

                    b.Property<int?>("RAM")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("Storage")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("typeStorage")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("DeviceName")
                        .IsUnique();

                    b.ToTable("Computers");

                    b.HasDiscriminator<int>("Type");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.PhysicalObjects.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Owner")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("Items");

                    b.HasDiscriminator<int>("Type");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.PhysicalObjects.PhysicalAssets.Loan.Loan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ProfessorId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("StudentId")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProfessorId");

                    b.HasIndex("StudentId");

                    b.ToTable("Loans");

                    b.HasDiscriminator<int>("Type");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.PhysicalObjects.PhysicalAssets.Request.RequestEMATP", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("EstimatedCompletionDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("RequestStartDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("longtext");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ComputerRequests");

                    b.HasDiscriminator<int>("Type");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.SchoolArea.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AreaType")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.Categories.AreaCategory", b =>
                {
                    b.HasBaseType("PaginaEEST1.Data.Models.Categories.Category");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.Categories.ItemCategory", b =>
                {
                    b.HasBaseType("PaginaEEST1.Data.Models.Categories.Category");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.Personal.Professor", b =>
                {
                    b.HasBaseType("PaginaEEST1.Data.Models.Personal.Person");

                    b.Property<string>("EducationLevel")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasDiscriminator().HasValue(4);
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.Personal.SchoolPrincipal", b =>
                {
                    b.HasBaseType("PaginaEEST1.Data.Models.Personal.Person");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.Personal.Storeroom", b =>
                {
                    b.HasBaseType("PaginaEEST1.Data.Models.Personal.Person");

                    b.HasDiscriminator().HasValue(3);
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.Personal.Student", b =>
                {
                    b.HasBaseType("PaginaEEST1.Data.Models.Personal.Person");

                    b.Property<string>("Shift")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasDiscriminator().HasValue(5);
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.PhysicalObjects.Desktop", b =>
                {
                    b.HasBaseType("PaginaEEST1.Data.Models.PhysicalObjects.Computer");

                    b.Property<string>("Location")
                        .HasColumnType("longtext");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.PhysicalObjects.Netbook", b =>
                {
                    b.HasBaseType("PaginaEEST1.Data.Models.PhysicalObjects.Computer");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Model")
                        .HasColumnType("longtext");

                    b.Property<int?>("NetbookLoanId")
                        .HasColumnType("int");

                    b.HasIndex("NetbookLoanId");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.PhysicalObjects.ReturnableItem", b =>
                {
                    b.HasBaseType("PaginaEEST1.Data.Models.PhysicalObjects.Item");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.PhysicalObjects.Componentes.NetbookLoan", b =>
                {
                    b.HasBaseType("PaginaEEST1.Data.Models.PhysicalObjects.PhysicalAssets.Loan.Loan");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.PhysicalObjects.PhysicalAssets.Request.FailureRequest", b =>
                {
                    b.HasBaseType("PaginaEEST1.Data.Models.PhysicalObjects.PhysicalAssets.Request.RequestEMATP");

                    b.Property<int>("ComputerId")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<string>("FailureDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Preority")
                        .HasColumnType("int");

                    b.HasIndex("ComputerId");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.PhysicalObjects.PhysicalAssets.Request.InstallationRequest", b =>
                {
                    b.HasBaseType("PaginaEEST1.Data.Models.PhysicalObjects.PhysicalAssets.Request.RequestEMATP");

                    b.Property<int>("ComputerId")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("int");

                    b.Property<string>("NameProgram")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("VersionProgram")
                        .HasColumnType("longtext");

                    b.HasIndex("ComputerId");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.PhysicalObjects.PhysicalAssets.Request.StudentAccountRequest", b =>
                {
                    b.HasBaseType("PaginaEEST1.Data.Models.PhysicalObjects.PhysicalAssets.Request.RequestEMATP");

                    b.Property<int?>("DNI")
                        .HasColumnType("int");

                    b.Property<string>("SchoolDivision")
                        .HasColumnType("longtext");

                    b.Property<string>("SchoolYear")
                        .HasColumnType("longtext");

                    b.Property<string>("StudentEmail")
                        .HasColumnType("longtext");

                    b.Property<string>("StudentName")
                        .HasColumnType("longtext");

                    b.Property<string>("StudentSurname")
                        .HasColumnType("longtext");

                    b.HasDiscriminator().HasValue(3);
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.Personal.EMATP", b =>
                {
                    b.HasBaseType("PaginaEEST1.Data.Models.Personal.Professor");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.People.PeopleAssets.Attendance", b =>
                {
                    b.HasOne("PaginaEEST1.Data.Models.Personal.Professor", null)
                        .WithMany("Attendances")
                        .HasForeignKey("ProfessorPersonId");
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.People.PeopleAssets.AttendanceRecord", b =>
                {
                    b.HasOne("PaginaEEST1.Data.Models.People.PeopleAssets.Attendance", null)
                        .WithMany("Records")
                        .HasForeignKey("AttendanceId");
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.PhysicalObjects.Item", b =>
                {
                    b.HasOne("PaginaEEST1.Data.Models.Categories.ItemCategory", "Category")
                        .WithMany("Items")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.PhysicalObjects.PhysicalAssets.Loan.Loan", b =>
                {
                    b.HasOne("PaginaEEST1.Data.Models.Personal.Professor", "Professor")
                        .WithMany()
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PaginaEEST1.Data.Models.Personal.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");

                    b.Navigation("Professor");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.SchoolArea.Area", b =>
                {
                    b.HasOne("PaginaEEST1.Data.Models.Categories.AreaCategory", "Category")
                        .WithMany("Areas")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.PhysicalObjects.Netbook", b =>
                {
                    b.HasOne("PaginaEEST1.Data.Models.PhysicalObjects.Componentes.NetbookLoan", null)
                        .WithMany("Netbooks")
                        .HasForeignKey("NetbookLoanId");
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.PhysicalObjects.PhysicalAssets.Request.FailureRequest", b =>
                {
                    b.HasOne("PaginaEEST1.Data.Models.PhysicalObjects.Computer", "Computer")
                        .WithMany()
                        .HasForeignKey("ComputerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Computer");
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.PhysicalObjects.PhysicalAssets.Request.InstallationRequest", b =>
                {
                    b.HasOne("PaginaEEST1.Data.Models.PhysicalObjects.Computer", "Computer")
                        .WithMany()
                        .HasForeignKey("ComputerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Computer");
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.People.PeopleAssets.Attendance", b =>
                {
                    b.Navigation("Records");
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.Categories.AreaCategory", b =>
                {
                    b.Navigation("Areas");
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.Categories.ItemCategory", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.Personal.Professor", b =>
                {
                    b.Navigation("Attendances");
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.PhysicalObjects.Componentes.NetbookLoan", b =>
                {
                    b.Navigation("Netbooks");
                });
#pragma warning restore 612, 618
        }
    }
}
