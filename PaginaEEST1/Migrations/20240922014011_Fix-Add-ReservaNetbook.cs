using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaginaEEST1.Migrations
{
    /// <inheritdoc />
    public partial class FixAddReservaNetbook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Ordenadores_NetbookOrdenadorId",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Ordenadores_Profesor_NetbookOrdenadorId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_NetbookOrdenadorId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_Profesor_NetbookOrdenadorId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "NetbookOrdenadorId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Profesor_NetbookOrdenadorId",
                table: "Personas");

            migrationBuilder.CreateTable(
                name: "ReservasDeNetbooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Materia = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProfesorId = table.Column<int>(type: "int", nullable: false),
                    AlumnoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservasDeNetbooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservasDeNetbooks_Personas_AlumnoId",
                        column: x => x.AlumnoId,
                        principalTable: "Personas",
                        principalColumn: "PersonaId");
                    table.ForeignKey(
                        name: "FK_ReservasDeNetbooks_Personas_ProfesorId",
                        column: x => x.ProfesorId,
                        principalTable: "Personas",
                        principalColumn: "PersonaId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ReservasDeNetbooks_AlumnoId",
                table: "ReservasDeNetbooks",
                column: "AlumnoId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservasDeNetbooks_ProfesorId",
                table: "ReservasDeNetbooks",
                column: "ProfesorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservasDeNetbooks");

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

            migrationBuilder.CreateIndex(
                name: "IX_Personas_NetbookOrdenadorId",
                table: "Personas",
                column: "NetbookOrdenadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_Profesor_NetbookOrdenadorId",
                table: "Personas",
                column: "Profesor_NetbookOrdenadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Ordenadores_NetbookOrdenadorId",
                table: "Personas",
                column: "NetbookOrdenadorId",
                principalTable: "Ordenadores",
                principalColumn: "OrdenadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Ordenadores_Profesor_NetbookOrdenadorId",
                table: "Personas",
                column: "Profesor_NetbookOrdenadorId",
                principalTable: "Ordenadores",
                principalColumn: "OrdenadorId");
        }
    }
}
