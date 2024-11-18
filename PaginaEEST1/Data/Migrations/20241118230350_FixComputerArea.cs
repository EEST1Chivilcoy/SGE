using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaginaEEST1.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixComputerArea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Computers_Areas_LocationId",
                table: "Computers");

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_Areas_LocationId",
                table: "Computers",
                column: "LocationId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Computers_Areas_LocationId",
                table: "Computers");

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_Areas_LocationId",
                table: "Computers",
                column: "LocationId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
