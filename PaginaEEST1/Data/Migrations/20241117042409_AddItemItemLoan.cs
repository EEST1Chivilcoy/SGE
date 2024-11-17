using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaginaEEST1.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddItemItemLoan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Item_ItemLoan",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    LoanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item_ItemLoan", x => new { x.ItemId, x.LoanId });
                    table.ForeignKey(
                        name: "FK_Item_ItemLoan_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Item_ItemLoan_Loans_LoanId",
                        column: x => x.LoanId,
                        principalTable: "Loans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Item_ItemLoan_LoanId",
                table: "Item_ItemLoan",
                column: "LoanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item_ItemLoan");

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
    }
}
