using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaginaEEST1.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixNetbookLoan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Computers_Loans_NetbookLoanId",
                table: "Computers");

            migrationBuilder.RenameColumn(
                name: "NetbookLoanId",
                table: "Computers",
                newName: "LoanId");

            migrationBuilder.RenameIndex(
                name: "IX_Computers_NetbookLoanId",
                table: "Computers",
                newName: "IX_Computers_LoanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_Loans_LoanId",
                table: "Computers",
                column: "LoanId",
                principalTable: "Loans",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Computers_Loans_LoanId",
                table: "Computers");

            migrationBuilder.RenameColumn(
                name: "LoanId",
                table: "Computers",
                newName: "NetbookLoanId");

            migrationBuilder.RenameIndex(
                name: "IX_Computers_LoanId",
                table: "Computers",
                newName: "IX_Computers_NetbookLoanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_Loans_NetbookLoanId",
                table: "Computers",
                column: "NetbookLoanId",
                principalTable: "Loans",
                principalColumn: "Id");
        }
    }
}
