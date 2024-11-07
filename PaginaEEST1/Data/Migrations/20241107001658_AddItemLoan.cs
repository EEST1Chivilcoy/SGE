using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaginaEEST1.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddItemLoan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemLoanId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemLoanId",
                table: "Items",
                column: "ItemLoanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Loans_ItemLoanId",
                table: "Items",
                column: "ItemLoanId",
                principalTable: "Loans",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Loans_ItemLoanId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_ItemLoanId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ItemLoanId",
                table: "Items");
        }
    }
}
