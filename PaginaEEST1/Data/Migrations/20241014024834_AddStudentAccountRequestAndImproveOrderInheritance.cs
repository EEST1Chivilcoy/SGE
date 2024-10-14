using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaginaEEST1.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentAccountRequestAndImproveOrderInheritance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ComputerId",
                table: "ComputerRequests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "SchoolDivision",
                table: "ComputerRequests",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "SchoolYear",
                table: "ComputerRequests",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "StudentEmail",
                table: "ComputerRequests",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "StudentName",
                table: "ComputerRequests",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "StudentSurname",
                table: "ComputerRequests",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SchoolDivision",
                table: "ComputerRequests");

            migrationBuilder.DropColumn(
                name: "SchoolYear",
                table: "ComputerRequests");

            migrationBuilder.DropColumn(
                name: "StudentEmail",
                table: "ComputerRequests");

            migrationBuilder.DropColumn(
                name: "StudentName",
                table: "ComputerRequests");

            migrationBuilder.DropColumn(
                name: "StudentSurname",
                table: "ComputerRequests");

            migrationBuilder.AlterColumn<int>(
                name: "ComputerId",
                table: "ComputerRequests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
