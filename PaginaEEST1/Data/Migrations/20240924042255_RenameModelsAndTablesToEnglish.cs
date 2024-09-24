using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaginaEEST1.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenameModelsAndTablesToEnglish : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Computers_ReservasDeNetbooks_NetbookLoanId",
                table: "Computers");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservasDeNetbooks_People_ProfessorId",
                table: "ReservasDeNetbooks");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservasDeNetbooks_People_StudentId",
                table: "ReservasDeNetbooks");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitudesOrdenador_Computers_ComputerId",
                table: "SolicitudesOrdenador");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitudesOrdenador_People_ProfessorId",
                table: "SolicitudesOrdenador");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SolicitudesOrdenador",
                table: "SolicitudesOrdenador");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReservasDeNetbooks",
                table: "ReservasDeNetbooks");

            migrationBuilder.RenameTable(
                name: "SolicitudesOrdenador",
                newName: "ComputerRequests");

            migrationBuilder.RenameTable(
                name: "ReservasDeNetbooks",
                newName: "NetbookLoans");

            migrationBuilder.RenameColumn(
                name: "typeComputer",
                table: "Computers",
                newName: "Type");

            migrationBuilder.RenameIndex(
                name: "IX_SolicitudesOrdenador_ProfessorId",
                table: "ComputerRequests",
                newName: "IX_ComputerRequests_ProfessorId");

            migrationBuilder.RenameIndex(
                name: "IX_SolicitudesOrdenador_ComputerId",
                table: "ComputerRequests",
                newName: "IX_ComputerRequests_ComputerId");

            migrationBuilder.RenameIndex(
                name: "IX_ReservasDeNetbooks_StudentId",
                table: "NetbookLoans",
                newName: "IX_NetbookLoans_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_ReservasDeNetbooks_ProfessorId",
                table: "NetbookLoans",
                newName: "IX_NetbookLoans_ProfessorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ComputerRequests",
                table: "ComputerRequests",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NetbookLoans",
                table: "NetbookLoans",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ComputerRequests_Computers_ComputerId",
                table: "ComputerRequests",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ComputerRequests_People_ProfessorId",
                table: "ComputerRequests",
                column: "ProfessorId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_NetbookLoans_NetbookLoanId",
                table: "Computers",
                column: "NetbookLoanId",
                principalTable: "NetbookLoans",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NetbookLoans_People_ProfessorId",
                table: "NetbookLoans",
                column: "ProfessorId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NetbookLoans_People_StudentId",
                table: "NetbookLoans",
                column: "StudentId",
                principalTable: "People",
                principalColumn: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComputerRequests_Computers_ComputerId",
                table: "ComputerRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ComputerRequests_People_ProfessorId",
                table: "ComputerRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Computers_NetbookLoans_NetbookLoanId",
                table: "Computers");

            migrationBuilder.DropForeignKey(
                name: "FK_NetbookLoans_People_ProfessorId",
                table: "NetbookLoans");

            migrationBuilder.DropForeignKey(
                name: "FK_NetbookLoans_People_StudentId",
                table: "NetbookLoans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NetbookLoans",
                table: "NetbookLoans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ComputerRequests",
                table: "ComputerRequests");

            migrationBuilder.RenameTable(
                name: "NetbookLoans",
                newName: "ReservasDeNetbooks");

            migrationBuilder.RenameTable(
                name: "ComputerRequests",
                newName: "SolicitudesOrdenador");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Computers",
                newName: "typeComputer");

            migrationBuilder.RenameIndex(
                name: "IX_NetbookLoans_StudentId",
                table: "ReservasDeNetbooks",
                newName: "IX_ReservasDeNetbooks_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_NetbookLoans_ProfessorId",
                table: "ReservasDeNetbooks",
                newName: "IX_ReservasDeNetbooks_ProfessorId");

            migrationBuilder.RenameIndex(
                name: "IX_ComputerRequests_ProfessorId",
                table: "SolicitudesOrdenador",
                newName: "IX_SolicitudesOrdenador_ProfessorId");

            migrationBuilder.RenameIndex(
                name: "IX_ComputerRequests_ComputerId",
                table: "SolicitudesOrdenador",
                newName: "IX_SolicitudesOrdenador_ComputerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReservasDeNetbooks",
                table: "ReservasDeNetbooks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SolicitudesOrdenador",
                table: "SolicitudesOrdenador",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_ReservasDeNetbooks_NetbookLoanId",
                table: "Computers",
                column: "NetbookLoanId",
                principalTable: "ReservasDeNetbooks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservasDeNetbooks_People_ProfessorId",
                table: "ReservasDeNetbooks",
                column: "ProfessorId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservasDeNetbooks_People_StudentId",
                table: "ReservasDeNetbooks",
                column: "StudentId",
                principalTable: "People",
                principalColumn: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitudesOrdenador_Computers_ComputerId",
                table: "SolicitudesOrdenador",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitudesOrdenador_People_ProfessorId",
                table: "SolicitudesOrdenador",
                column: "ProfessorId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
