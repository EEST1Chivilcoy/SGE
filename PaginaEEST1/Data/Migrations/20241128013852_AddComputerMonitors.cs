using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaginaEEST1.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddComputerMonitors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MonitorId",
                table: "Computers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ComputerMonitors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Brand = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Model = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SizeInInches = table.Column<int>(type: "int", nullable: false),
                    Resolution = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConnectionTypes = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AspectRatio = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerMonitors", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_MonitorId",
                table: "Computers",
                column: "MonitorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_ComputerMonitors_MonitorId",
                table: "Computers",
                column: "MonitorId",
                principalTable: "ComputerMonitors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Computers_ComputerMonitors_MonitorId",
                table: "Computers");

            migrationBuilder.DropTable(
                name: "ComputerMonitors");

            migrationBuilder.DropIndex(
                name: "IX_Computers_MonitorId",
                table: "Computers");

            migrationBuilder.DropColumn(
                name: "MonitorId",
                table: "Computers");
        }
    }
}
