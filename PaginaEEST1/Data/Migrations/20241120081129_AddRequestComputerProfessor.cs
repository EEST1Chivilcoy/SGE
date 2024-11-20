using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaginaEEST1.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRequestComputerProfessor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfessorId",
                table: "ComputerRequests",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ComputerRequests_ProfessorId",
                table: "ComputerRequests",
                column: "ProfessorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ComputerRequests_People_ProfessorId",
                table: "ComputerRequests",
                column: "ProfessorId",
                principalTable: "People",
                principalColumn: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComputerRequests_People_ProfessorId",
                table: "ComputerRequests");

            migrationBuilder.DropIndex(
                name: "IX_ComputerRequests_ProfessorId",
                table: "ComputerRequests");

            migrationBuilder.DropColumn(
                name: "ProfessorId",
                table: "ComputerRequests");
        }
    }
}
