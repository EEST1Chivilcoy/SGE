using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaginaEEST1.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSchoolEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_People_ProfessorPersonId",
                table: "Attendances");

            migrationBuilder.RenameColumn(
                name: "ProfessorPersonId",
                table: "Attendances",
                newName: "SchoolEmployeePersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendances_ProfessorPersonId",
                table: "Attendances",
                newName: "IX_Attendances_SchoolEmployeePersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_People_SchoolEmployeePersonId",
                table: "Attendances",
                column: "SchoolEmployeePersonId",
                principalTable: "People",
                principalColumn: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_People_SchoolEmployeePersonId",
                table: "Attendances");

            migrationBuilder.RenameColumn(
                name: "SchoolEmployeePersonId",
                table: "Attendances",
                newName: "ProfessorPersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendances_SchoolEmployeePersonId",
                table: "Attendances",
                newName: "IX_Attendances_ProfessorPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_People_ProfessorPersonId",
                table: "Attendances",
                column: "ProfessorPersonId",
                principalTable: "People",
                principalColumn: "PersonId");
        }
    }
}
