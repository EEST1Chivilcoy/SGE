using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaginaEEST1.Data.Migrations
{
    /// <inheritdoc />
    public partial class Fix_Requests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfessorId",
                table: "ComputerRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ComputerRequests_ProfessorId",
                table: "ComputerRequests",
                column: "ProfessorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ComputerRequests_People_ProfessorId",
                table: "ComputerRequests",
                column: "ProfessorId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
