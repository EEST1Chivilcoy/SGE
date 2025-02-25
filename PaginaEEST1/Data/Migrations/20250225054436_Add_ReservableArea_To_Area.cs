using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaginaEEST1.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_ReservableArea_To_Area : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReservableInfoId",
                table: "Areas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ReservableAreas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservableAreas", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AvailableSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Day = table.Column<int>(type: "int", nullable: false),
                    OpeningTime = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    ClosingTime = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    ReservableAreaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvailableSchedules_ReservableAreas_ReservableAreaId",
                        column: x => x.ReservableAreaId,
                        principalTable: "ReservableAreas",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StartTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ReservedBy = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReservableAreaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_ReservableAreas_ReservableAreaId",
                        column: x => x.ReservableAreaId,
                        principalTable: "ReservableAreas",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_ReservableInfoId",
                table: "Areas",
                column: "ReservableInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableSchedules_ReservableAreaId",
                table: "AvailableSchedules",
                column: "ReservableAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReservableAreaId",
                table: "Reservations",
                column: "ReservableAreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_ReservableAreas_ReservableInfoId",
                table: "Areas",
                column: "ReservableInfoId",
                principalTable: "ReservableAreas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Areas_ReservableAreas_ReservableInfoId",
                table: "Areas");

            migrationBuilder.DropTable(
                name: "AvailableSchedules");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "ReservableAreas");

            migrationBuilder.DropIndex(
                name: "IX_Areas_ReservableInfoId",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "ReservableInfoId",
                table: "Areas");
        }
    }
}
