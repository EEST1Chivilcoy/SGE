﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PaginaEEST1.Data;

#nullable disable

namespace PaginaEEST1.Data.Migrations
{
    [DbContext(typeof(PaginaDbContext))]
    [Migration("20241120112101_AddEntraIDRoleToPerson")]
    partial class AddEntraIDRoleToPerson
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Item_ItemLoan", b =>
                {
                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("LoanId")
                        .HasColumnType("int");

                    b.HasKey("ItemId", "LoanId");

                    b.HasIndex("LoanId");

                    b.ToTable("Item_ItemLoan");
                });

            modelBuilder.Entity("Netbook_NetbookLoan", b =>
                {
                    b.Property<int>("LoanId")
                        .HasColumnType("int");

                    b.Property<int>("Netbookid")
                        .HasColumnType("int");

                    b.HasKey("LoanId", "Netbookid");

                    b.HasIndex("Netbookid");

                    b.ToTable("Netbook_NetbookLoan");
                });

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

            modelBuilder.Entity("PaginaEEST1.Data.Models.Images.AbstractImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("ImageContent")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<string>("ImageName")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("ImageType")
                        .HasColumnType("int");

                    b.Property<string>("TypeFile")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Images");

                    b.HasDiscriminator<int>("ImageType");

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

                    b.Property<string>("SchoolEmployeePersonId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("SchoolEmployeePersonId");

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
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("EntraIDRole")
                        .IsRequired()
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

                    b.Property<TimeOnly>("FinishTime")
                        .HasColumnType("time(6)");

                    b.Property<string>("ProfessorId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateOnly>("RequiredDate")
                        .HasColumnType("date");

                    b.Property<string>("SchoolGrade")
                        .HasColumnType("longtext");

                    b.Property<TimeOnly>("StartTime")
                        .HasColumnType("time(6)");

                    b.Property<int>("Status")
                        .HasMaxLength(255)
                        .HasColumnType("int");

                    b.Property<DateTime>("SubmitDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProfessorId");

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

                    b.Property<int>("AreaGuidance")
                        .HasColumnType("int");

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

            modelBuilder.Entity("PaginaEEST1.Data.Models.Images.AreaImage_Area", b =>
                {
                    b.HasBaseType("PaginaEEST1.Data.Models.Images.AbstractImage");

                    b.Property<int>("AreaId")
                        .HasColumnType("int");

                    b.HasIndex("AreaId")
                        .IsUnique();

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.Images.ItemImage_Item", b =>
                {
                    b.HasBaseType("PaginaEEST1.Data.Models.Images.AbstractImage");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.HasIndex("ItemId")
                        .IsUnique();

                    b.HasDiscriminator().HasValue(3);
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.Images.ProfileImage_Person", b =>
                {
                    b.HasBaseType("PaginaEEST1.Data.Models.Images.AbstractImage");

                    b.Property<string>("PersonId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.People.SchoolEmployee", b =>
                {
                    b.HasBaseType("PaginaEEST1.Data.Models.Personal.Person");

                    b.HasDiscriminator().HasValue(6);
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

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.HasIndex("LocationId");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.PhysicalObjects.Netbook", b =>
                {
                    b.HasBaseType("PaginaEEST1.Data.Models.PhysicalObjects.Computer");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Model")
                        .HasColumnType("longtext");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.PhysicalObjects.ConsumableItem", b =>
                {
                    b.HasBaseType("PaginaEEST1.Data.Models.PhysicalObjects.Item");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.PhysicalObjects.ReturnableItem", b =>
                {
                    b.HasBaseType("PaginaEEST1.Data.Models.PhysicalObjects.Item");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.PhysicalObjects.PhysicalAssets.Loan.ItemLoan", b =>
                {
                    b.HasBaseType("PaginaEEST1.Data.Models.PhysicalObjects.PhysicalAssets.Loan.Loan");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.PhysicalObjects.PhysicalAssets.Loan.NetbookLoan", b =>
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

                    b.Property<string>("ProfessorId")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("varchar(255)");

                    b.HasIndex("ComputerId");

                    b.HasIndex("ProfessorId");

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

                    b.Property<string>("ProfessorId")
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("VersionProgram")
                        .HasColumnType("longtext");

                    b.HasIndex("ComputerId");

                    b.HasIndex("ProfessorId");

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
                    b.HasBaseType("PaginaEEST1.Data.Models.People.SchoolEmployee");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.Personal.Professor", b =>
                {
                    b.HasBaseType("PaginaEEST1.Data.Models.People.SchoolEmployee");

                    b.Property<string>("EducationLevel")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasDiscriminator().HasValue(4);
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.Personal.SchoolPrincipal", b =>
                {
                    b.HasBaseType("PaginaEEST1.Data.Models.People.SchoolEmployee");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.Personal.Storeroom", b =>
                {
                    b.HasBaseType("PaginaEEST1.Data.Models.People.SchoolEmployee");

                    b.HasDiscriminator().HasValue(3);
                });

            modelBuilder.Entity("Item_ItemLoan", b =>
                {
                    b.HasOne("PaginaEEST1.Data.Models.PhysicalObjects.ReturnableItem", null)
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PaginaEEST1.Data.Models.PhysicalObjects.PhysicalAssets.Loan.ItemLoan", null)
                        .WithMany()
                        .HasForeignKey("LoanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Netbook_NetbookLoan", b =>
                {
                    b.HasOne("PaginaEEST1.Data.Models.PhysicalObjects.PhysicalAssets.Loan.NetbookLoan", null)
                        .WithMany()
                        .HasForeignKey("LoanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PaginaEEST1.Data.Models.PhysicalObjects.Netbook", null)
                        .WithMany()
                        .HasForeignKey("Netbookid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.People.PeopleAssets.Attendance", b =>
                {
                    b.HasOne("PaginaEEST1.Data.Models.People.SchoolEmployee", null)
                        .WithMany("Attendances")
                        .HasForeignKey("SchoolEmployeePersonId");
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

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.SchoolArea.Area", b =>
                {
                    b.HasOne("PaginaEEST1.Data.Models.Categories.AreaCategory", "Category")
                        .WithMany("Areas")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.Images.AreaImage_Area", b =>
                {
                    b.HasOne("PaginaEEST1.Data.Models.SchoolArea.Area", "Area")
                        .WithOne("ImageArea")
                        .HasForeignKey("PaginaEEST1.Data.Models.Images.AreaImage_Area", "AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Area");
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.Images.ItemImage_Item", b =>
                {
                    b.HasOne("PaginaEEST1.Data.Models.PhysicalObjects.Item", "Item")
                        .WithOne("ItemImage")
                        .HasForeignKey("PaginaEEST1.Data.Models.Images.ItemImage_Item", "ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.Images.ProfileImage_Person", b =>
                {
                    b.HasOne("PaginaEEST1.Data.Models.Personal.Person", "Person")
                        .WithOne("ProfileImage")
                        .HasForeignKey("PaginaEEST1.Data.Models.Images.ProfileImage_Person", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.PhysicalObjects.Desktop", b =>
                {
                    b.HasOne("PaginaEEST1.Data.Models.SchoolArea.Area", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Location");
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.PhysicalObjects.PhysicalAssets.Request.FailureRequest", b =>
                {
                    b.HasOne("PaginaEEST1.Data.Models.PhysicalObjects.Computer", "Computer")
                        .WithMany()
                        .HasForeignKey("ComputerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PaginaEEST1.Data.Models.Personal.Professor", "Professor")
                        .WithMany()
                        .HasForeignKey("ProfessorId");

                    b.Navigation("Computer");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.PhysicalObjects.PhysicalAssets.Request.InstallationRequest", b =>
                {
                    b.HasOne("PaginaEEST1.Data.Models.PhysicalObjects.Computer", "Computer")
                        .WithMany()
                        .HasForeignKey("ComputerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PaginaEEST1.Data.Models.Personal.Professor", "Professor")
                        .WithMany()
                        .HasForeignKey("ProfessorId");

                    b.Navigation("Computer");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.People.PeopleAssets.Attendance", b =>
                {
                    b.Navigation("Records");
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.Personal.Person", b =>
                {
                    b.Navigation("ProfileImage");
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.PhysicalObjects.Item", b =>
                {
                    b.Navigation("ItemImage");
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.SchoolArea.Area", b =>
                {
                    b.Navigation("ImageArea");
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.Categories.AreaCategory", b =>
                {
                    b.Navigation("Areas");
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.Categories.ItemCategory", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.People.SchoolEmployee", b =>
                {
                    b.Navigation("Attendances");
                });
#pragma warning restore 612, 618
        }
    }
}