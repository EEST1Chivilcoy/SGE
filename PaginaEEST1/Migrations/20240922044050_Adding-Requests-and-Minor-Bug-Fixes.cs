using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaginaEEST1.Migrations
{
    /// <inheritdoc />
    public partial class AddingRequestsandMinorBugFixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Ordenadores");

            migrationBuilder.RenameColumn(
                name: "Sistema_Operativo",
                table: "Ordenadores",
                newName: "SistemaOperativo");

            migrationBuilder.UpdateData(
                table: "Ordenadores",
                keyColumn: "NombreOrdenador",
                keyValue: null,
                column: "NombreOrdenador",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "NombreOrdenador",
                table: "Ordenadores",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SolicitudesOrdenador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    OrdenadorId = table.Column<int>(type: "int", nullable: false),
                    ProfesorId = table.Column<int>(type: "int", nullable: false),
                    DescripcionCorta = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaSolicitud = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaFinalizacionEstimada = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    DescripcionFallo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Prioridad = table.Column<int>(type: "int", nullable: true),
                    NombrePrograma = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VersionPrograma = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitudesOrdenador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolicitudesOrdenador_Ordenadores_OrdenadorId",
                        column: x => x.OrdenadorId,
                        principalTable: "Ordenadores",
                        principalColumn: "OrdenadorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SolicitudesOrdenador_Personas_ProfesorId",
                        column: x => x.ProfesorId,
                        principalTable: "Personas",
                        principalColumn: "PersonaId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenadores_NombreOrdenador",
                table: "Ordenadores",
                column: "NombreOrdenador",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudesOrdenador_OrdenadorId",
                table: "SolicitudesOrdenador",
                column: "OrdenadorId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudesOrdenador_ProfesorId",
                table: "SolicitudesOrdenador",
                column: "ProfesorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SolicitudesOrdenador");

            migrationBuilder.DropIndex(
                name: "IX_Ordenadores_NombreOrdenador",
                table: "Ordenadores");

            migrationBuilder.RenameColumn(
                name: "SistemaOperativo",
                table: "Ordenadores",
                newName: "Sistema_Operativo");

            migrationBuilder.AlterColumn<string>(
                name: "NombreOrdenador",
                table: "Ordenadores",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Ordenadores",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
