using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaginaEEST1.Migrations
{
    /// <inheritdoc />
    public partial class Add_Ordenadores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Computadoras_Personas_AlumnoId",
                table: "Computadoras");

            migrationBuilder.DropForeignKey(
                name: "FK_Computadoras_Personas_ProfesorId",
                table: "Computadoras");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Computadoras",
                table: "Computadoras");

            migrationBuilder.DropIndex(
                name: "IX_Computadoras_AlumnoId",
                table: "Computadoras");

            migrationBuilder.DropIndex(
                name: "IX_Computadoras_ProfesorId",
                table: "Computadoras");

            migrationBuilder.DropColumn(
                name: "FechaAdquisicion",
                table: "Computadoras");

            migrationBuilder.RenameTable(
                name: "Computadoras",
                newName: "Ordenador");

            migrationBuilder.RenameColumn(
                name: "TipoComputadora",
                table: "Ordenador",
                newName: "TipoOrdenador");

            migrationBuilder.RenameColumn(
                name: "SistemaOperativo",
                table: "Ordenador",
                newName: "Sistema_Operativo");

            migrationBuilder.RenameColumn(
                name: "ProfesorId",
                table: "Ordenador",
                newName: "RAM");

            migrationBuilder.RenameColumn(
                name: "AlumnoId",
                table: "Ordenador",
                newName: "Almacenamiento");

            migrationBuilder.RenameColumn(
                name: "ComputadoraId",
                table: "Ordenador",
                newName: "OrdenadorId");

            migrationBuilder.AddColumn<int>(
                name: "NetbookOrdenadorId",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Profesor_NetbookOrdenadorId",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Estado",
                table: "Ordenador",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Modelo",
                table: "Ordenador",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "Prestamo",
                table: "Ordenador",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Procesador",
                table: "Ordenador",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ordenador",
                table: "Ordenador",
                column: "OrdenadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_NetbookOrdenadorId",
                table: "Personas",
                column: "NetbookOrdenadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_Profesor_NetbookOrdenadorId",
                table: "Personas",
                column: "Profesor_NetbookOrdenadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Ordenador_NetbookOrdenadorId",
                table: "Personas",
                column: "NetbookOrdenadorId",
                principalTable: "Ordenador",
                principalColumn: "OrdenadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Ordenador_Profesor_NetbookOrdenadorId",
                table: "Personas",
                column: "Profesor_NetbookOrdenadorId",
                principalTable: "Ordenador",
                principalColumn: "OrdenadorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Ordenador_NetbookOrdenadorId",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Ordenador_Profesor_NetbookOrdenadorId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_NetbookOrdenadorId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_Profesor_NetbookOrdenadorId",
                table: "Personas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ordenador",
                table: "Ordenador");

            migrationBuilder.DropColumn(
                name: "NetbookOrdenadorId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Profesor_NetbookOrdenadorId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Modelo",
                table: "Ordenador");

            migrationBuilder.DropColumn(
                name: "Prestamo",
                table: "Ordenador");

            migrationBuilder.DropColumn(
                name: "Procesador",
                table: "Ordenador");

            migrationBuilder.RenameTable(
                name: "Ordenador",
                newName: "Computadoras");

            migrationBuilder.RenameColumn(
                name: "TipoOrdenador",
                table: "Computadoras",
                newName: "TipoComputadora");

            migrationBuilder.RenameColumn(
                name: "Sistema_Operativo",
                table: "Computadoras",
                newName: "SistemaOperativo");

            migrationBuilder.RenameColumn(
                name: "RAM",
                table: "Computadoras",
                newName: "ProfesorId");

            migrationBuilder.RenameColumn(
                name: "Almacenamiento",
                table: "Computadoras",
                newName: "AlumnoId");

            migrationBuilder.RenameColumn(
                name: "OrdenadorId",
                table: "Computadoras",
                newName: "ComputadoraId");

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Computadoras",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaAdquisicion",
                table: "Computadoras",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Computadoras",
                table: "Computadoras",
                column: "ComputadoraId");

            migrationBuilder.CreateIndex(
                name: "IX_Computadoras_AlumnoId",
                table: "Computadoras",
                column: "AlumnoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Computadoras_ProfesorId",
                table: "Computadoras",
                column: "ProfesorId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Computadoras_Personas_AlumnoId",
                table: "Computadoras",
                column: "AlumnoId",
                principalTable: "Personas",
                principalColumn: "PersonaId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Computadoras_Personas_ProfesorId",
                table: "Computadoras",
                column: "ProfesorId",
                principalTable: "Personas",
                principalColumn: "PersonaId",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
