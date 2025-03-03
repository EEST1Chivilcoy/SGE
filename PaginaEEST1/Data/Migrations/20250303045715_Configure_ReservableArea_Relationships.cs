using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaginaEEST1.Data.Migrations
{
    /// <inheritdoc />
    public partial class Configure_ReservableArea_Relationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Areas_ReservableAreas_ReservableInfoId",
                table: "Areas");

            migrationBuilder.DropForeignKey(
                name: "FK_AvailableSchedules_ReservableAreas_ReservableAreaId",
                table: "AvailableSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_ReservableAreas_ReservableAreaId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Areas_ReservableInfoId",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "ReservableInfoId",
                table: "Areas");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ReservableAreas",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_AvailableSchedules_ReservableAreas_ReservableAreaId",
                table: "AvailableSchedules",
                column: "ReservableAreaId",
                principalTable: "ReservableAreas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservableAreas_Areas_Id",
                table: "ReservableAreas",
                column: "Id",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_ReservableAreas_ReservableAreaId",
                table: "Reservations",
                column: "ReservableAreaId",
                principalTable: "ReservableAreas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AvailableSchedules_ReservableAreas_ReservableAreaId",
                table: "AvailableSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservableAreas_Areas_Id",
                table: "ReservableAreas");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_ReservableAreas_ReservableAreaId",
                table: "Reservations");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ReservableAreas",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "ReservableInfoId",
                table: "Areas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Areas_ReservableInfoId",
                table: "Areas",
                column: "ReservableInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_ReservableAreas_ReservableInfoId",
                table: "Areas",
                column: "ReservableInfoId",
                principalTable: "ReservableAreas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AvailableSchedules_ReservableAreas_ReservableAreaId",
                table: "AvailableSchedules",
                column: "ReservableAreaId",
                principalTable: "ReservableAreas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_ReservableAreas_ReservableAreaId",
                table: "Reservations",
                column: "ReservableAreaId",
                principalTable: "ReservableAreas",
                principalColumn: "Id");
        }
    }
}
