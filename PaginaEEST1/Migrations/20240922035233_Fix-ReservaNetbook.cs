using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaginaEEST1.Migrations
{
    /// <inheritdoc />
    public partial class FixReservaNetbook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReservaNetbookId",
                table: "Ordenadores",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ordenadores_ReservaNetbookId",
                table: "Ordenadores",
                column: "ReservaNetbookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ordenadores_ReservasDeNetbooks_ReservaNetbookId",
                table: "Ordenadores",
                column: "ReservaNetbookId",
                principalTable: "ReservasDeNetbooks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ordenadores_ReservasDeNetbooks_ReservaNetbookId",
                table: "Ordenadores");

            migrationBuilder.DropIndex(
                name: "IX_Ordenadores_ReservaNetbookId",
                table: "Ordenadores");

            migrationBuilder.DropColumn(
                name: "ReservaNetbookId",
                table: "Ordenadores");
        }
    }
}
