using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaginaEEST1.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNetbookNetbookLoanRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Computers_Loans_LoanId",
                table: "Computers");

            migrationBuilder.DropIndex(
                name: "IX_Computers_LoanId",
                table: "Computers");

            migrationBuilder.DropColumn(
                name: "LoanId",
                table: "Computers");

            migrationBuilder.CreateTable(
                name: "Netbook_NetbookLoan",
                columns: table => new
                {
                    LoanId = table.Column<int>(type: "int", nullable: false),
                    Netbookid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Netbook_NetbookLoan", x => new { x.LoanId, x.Netbookid });
                    table.ForeignKey(
                        name: "FK_Netbook_NetbookLoan_Computers_Netbookid",
                        column: x => x.Netbookid,
                        principalTable: "Computers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Netbook_NetbookLoan_Loans_LoanId",
                        column: x => x.LoanId,
                        principalTable: "Loans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Netbook_NetbookLoan_Netbookid",
                table: "Netbook_NetbookLoan",
                column: "Netbookid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Netbook_NetbookLoan");

            migrationBuilder.AddColumn<int>(
                name: "LoanId",
                table: "Computers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Computers_LoanId",
                table: "Computers",
                column: "LoanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_Loans_LoanId",
                table: "Computers",
                column: "LoanId",
                principalTable: "Loans",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
