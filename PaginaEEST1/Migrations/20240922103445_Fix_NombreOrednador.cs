using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaginaEEST1.Migrations
{
    /// <inheritdoc />
    public partial class Fix_NombreOrednador : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NombreOrdenador",
                table: "Ordenadores",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Ordenadores",
                keyColumn: "NombreOrdenador",
                keyValue: null,
                column: "NombreOrdenador",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "NombreOrdenador",
                table: "Ordenadores",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
