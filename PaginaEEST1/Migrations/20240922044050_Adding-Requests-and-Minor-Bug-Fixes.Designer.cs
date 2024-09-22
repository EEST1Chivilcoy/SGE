﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PaginaEEST1.Data;

#nullable disable

namespace PaginaEEST1.Migrations
{
    [DbContext(typeof(PaginaDbContext))]
    [Migration("20240922044050_Adding-Requests-and-Minor-Bug-Fixes")]
    partial class AddingRequestsandMinorBugFixes
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("PaginaEEST1.Data.Models.Objetos_Fisicos.Componentes.ReservaNetbook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AlumnoId")
                        .HasColumnType("int");

                    b.Property<string>("Materia")
                        .HasColumnType("longtext");

                    b.Property<int>("ProfesorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlumnoId");

                    b.HasIndex("ProfesorId");

                    b.ToTable("ReservasDeNetbooks");
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.Objetos_Fisicos.Componentes.SolicitudOrdenador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DescripcionCorta")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaFinalizacionEstimada")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("FechaSolicitud")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("OrdenadorId")
                        .HasColumnType("int");

                    b.Property<int>("ProfesorId")
                        .HasColumnType("int");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrdenadorId");

                    b.HasIndex("ProfesorId");

                    b.ToTable("SolicitudesOrdenador");

                    b.HasDiscriminator<int>("Tipo");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.Objetos_Fisicos.Ordenador", b =>
                {
                    b.Property<int>("OrdenadorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("OrdenadorId"));

                    b.Property<int?>("Almacenamiento")
                        .HasColumnType("int");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<string>("NombreOrdenador")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Procesador")
                        .HasColumnType("longtext");

                    b.Property<int?>("RAM")
                        .HasColumnType("int");

                    b.Property<string>("SistemaOperativo")
                        .HasColumnType("longtext");

                    b.Property<int>("TipoOrdenador")
                        .HasColumnType("int");

                    b.Property<string>("tipoAlmacenamiento")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("OrdenadorId");

                    b.HasIndex("NombreOrdenador")
                        .IsUnique();

                    b.ToTable("Ordenadores");

                    b.HasDiscriminator<int>("TipoOrdenador");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.Personal.Persona", b =>
                {
                    b.Property<int>("PersonaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("PersonaId"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Direccion")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Documento")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("FechaNacimiento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("TipoPersona")
                        .HasColumnType("int");

                    b.HasKey("PersonaId");

                    b.ToTable("Personas");

                    b.HasDiscriminator<int>("TipoPersona");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.Objetos_Fisicos.Componentes.SolicitudFallo", b =>
                {
                    b.HasBaseType("PaginaEEST1.Data.Models.Objetos_Fisicos.Componentes.SolicitudOrdenador");

                    b.Property<string>("DescripcionFallo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Prioridad")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.Objetos_Fisicos.Componentes.SolicitudInstalacion", b =>
                {
                    b.HasBaseType("PaginaEEST1.Data.Models.Objetos_Fisicos.Componentes.SolicitudOrdenador");

                    b.Property<string>("NombrePrograma")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("VersionPrograma")
                        .HasColumnType("longtext");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.Objetos_Fisicos.Computadora", b =>
                {
                    b.HasBaseType("PaginaEEST1.Data.Models.Objetos_Fisicos.Ordenador");

                    b.Property<string>("Ubicacion")
                        .HasColumnType("longtext");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.Objetos_Fisicos.Netbook", b =>
                {
                    b.HasBaseType("PaginaEEST1.Data.Models.Objetos_Fisicos.Ordenador");

                    b.Property<string>("Modelo")
                        .HasColumnType("longtext");

                    b.Property<bool>("Prestamo")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("ReservaNetbookId")
                        .HasColumnType("int");

                    b.HasIndex("ReservaNetbookId");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.Personal.Alumno", b =>
                {
                    b.HasBaseType("PaginaEEST1.Data.Models.Personal.Persona");

                    b.Property<string>("Turno_Cursada")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasDiscriminator().HasValue(5);
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.Personal.Directivo", b =>
                {
                    b.HasBaseType("PaginaEEST1.Data.Models.Personal.Persona");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.Personal.EMATP", b =>
                {
                    b.HasBaseType("PaginaEEST1.Data.Models.Personal.Persona");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.Personal.Paniol", b =>
                {
                    b.HasBaseType("PaginaEEST1.Data.Models.Personal.Persona");

                    b.HasDiscriminator().HasValue(3);
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.Personal.Profesor", b =>
                {
                    b.HasBaseType("PaginaEEST1.Data.Models.Personal.Persona");

                    b.Property<string>("NivelEstudios")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Titulo")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasDiscriminator().HasValue(4);
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.Objetos_Fisicos.Componentes.ReservaNetbook", b =>
                {
                    b.HasOne("PaginaEEST1.Data.Models.Personal.Alumno", "alumno")
                        .WithMany()
                        .HasForeignKey("AlumnoId");

                    b.HasOne("PaginaEEST1.Data.Models.Personal.Profesor", "profesor")
                        .WithMany()
                        .HasForeignKey("ProfesorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("alumno");

                    b.Navigation("profesor");
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.Objetos_Fisicos.Componentes.SolicitudOrdenador", b =>
                {
                    b.HasOne("PaginaEEST1.Data.Models.Objetos_Fisicos.Ordenador", "ordenador")
                        .WithMany()
                        .HasForeignKey("OrdenadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PaginaEEST1.Data.Models.Personal.Profesor", "ProfesorSolicitante")
                        .WithMany()
                        .HasForeignKey("ProfesorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProfesorSolicitante");

                    b.Navigation("ordenador");
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.Objetos_Fisicos.Netbook", b =>
                {
                    b.HasOne("PaginaEEST1.Data.Models.Objetos_Fisicos.Componentes.ReservaNetbook", null)
                        .WithMany("netbooks")
                        .HasForeignKey("ReservaNetbookId");
                });

            modelBuilder.Entity("PaginaEEST1.Data.Models.Objetos_Fisicos.Componentes.ReservaNetbook", b =>
                {
                    b.Navigation("netbooks");
                });
#pragma warning restore 612, 618
        }
    }
}
