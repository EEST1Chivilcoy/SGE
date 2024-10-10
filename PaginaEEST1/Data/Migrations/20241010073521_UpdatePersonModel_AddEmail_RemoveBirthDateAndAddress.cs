using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaginaEEST1.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePersonModel_AddEmail_RemoveBirthDateAndAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "People");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "People",
                newName: "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "People",
                newName: "Address");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "People",
                type: "datetime(6)",
                nullable: true);
        }
    }
}
