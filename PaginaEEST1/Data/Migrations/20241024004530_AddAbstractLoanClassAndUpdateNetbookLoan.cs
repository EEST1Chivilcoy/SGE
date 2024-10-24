using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaginaEEST1.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAbstractLoanClassAndUpdateNetbookLoan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "Subject",
                table: "NetbookLoans");

            migrationBuilder.RenameTable(
                name: "NetbookLoans",
                newName: "Loans");

            migrationBuilder.RenameIndex(
                name: "IX_NetbookLoans_StudentId",
                table: "Loans",
                newName: "IX_Loans_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_NetbookLoans_ProfessorId",
                table: "Loans",
                newName: "IX_Loans_ProfessorId");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Loans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Loans",
                table: "Loans",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_Loans_NetbookLoanId",
                table: "Computers",
                column: "NetbookLoanId",
                principalTable: "Loans",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_People_ProfessorId",
                table: "Loans",
                column: "ProfessorId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_People_StudentId",
                table: "Loans",
                column: "StudentId",
                principalTable: "People",
                principalColumn: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Computers_Loans_NetbookLoanId",
                table: "Computers");

            migrationBuilder.DropForeignKey(
                name: "FK_Loans_People_ProfessorId",
                table: "Loans");

            migrationBuilder.DropForeignKey(
                name: "FK_Loans_People_StudentId",
                table: "Loans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Loans",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Loans");

            migrationBuilder.RenameTable(
                name: "Loans",
                newName: "NetbookLoans");

            migrationBuilder.RenameIndex(
                name: "IX_Loans_StudentId",
                table: "NetbookLoans",
                newName: "IX_NetbookLoans_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Loans_ProfessorId",
                table: "NetbookLoans",
                newName: "IX_NetbookLoans_ProfessorId");

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "NetbookLoans",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NetbookLoans",
                table: "NetbookLoans",
                column: "Id");

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
    }
}
