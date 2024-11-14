using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaginaEEST1.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLoan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_People_StudentId",
                table: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_Loans_StudentId",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Loans");

            migrationBuilder.AddColumn<TimeOnly>(
                name: "FinishTime",
                table: "Loans",
                type: "time(6)",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<DateOnly>(
                name: "RequiredDate",
                table: "Loans",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "SchoolGrade",
                table: "Loans",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<TimeOnly>(
                name: "StartTime",
                table: "Loans",
                type: "time(6)",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<DateTime>(
                name: "SubmitDate",
                table: "Loans",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinishTime",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "RequiredDate",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "SchoolGrade",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "SubmitDate",
                table: "Loans");

            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "Loans",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_StudentId",
                table: "Loans",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_People_StudentId",
                table: "Loans",
                column: "StudentId",
                principalTable: "People",
                principalColumn: "PersonId");
        }
    }
}
