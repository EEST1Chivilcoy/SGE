using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaginaEEST1.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDNIAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ShortDescription",
                table: "ComputerRequests",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "DNI",
                table: "ComputerRequests",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DNI",
                table: "ComputerRequests");

            migrationBuilder.UpdateData(
                table: "ComputerRequests",
                keyColumn: "ShortDescription",
                keyValue: null,
                column: "ShortDescription",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "ShortDescription",
                table: "ComputerRequests",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
