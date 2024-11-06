using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaginaEEST1.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAreaLocationDesktop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Computers");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Computers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Computers_LocationId",
                table: "Computers",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_Areas_LocationId",
                table: "Computers",
                column: "LocationId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Computers_Areas_LocationId",
                table: "Computers");

            migrationBuilder.DropIndex(
                name: "IX_Computers_LocationId",
                table: "Computers");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Computers");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Computers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
