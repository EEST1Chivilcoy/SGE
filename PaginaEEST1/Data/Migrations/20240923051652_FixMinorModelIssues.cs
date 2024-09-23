using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaginaEEST1.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixMinorModelIssues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SolicitudesOrdenador_DispositivosComputacionales_OrdenadorId",
                table: "SolicitudesOrdenador");

            migrationBuilder.RenameColumn(
                name: "OrdenadorId",
                table: "SolicitudesOrdenador",
                newName: "DispositivoId");

            migrationBuilder.RenameIndex(
                name: "IX_SolicitudesOrdenador_OrdenadorId",
                table: "SolicitudesOrdenador",
                newName: "IX_SolicitudesOrdenador_DispositivoId");

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitudesOrdenador_DispositivosComputacionales_Dispositivo~",
                table: "SolicitudesOrdenador",
                column: "DispositivoId",
                principalTable: "DispositivosComputacionales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SolicitudesOrdenador_DispositivosComputacionales_Dispositivo~",
                table: "SolicitudesOrdenador");

            migrationBuilder.RenameColumn(
                name: "DispositivoId",
                table: "SolicitudesOrdenador",
                newName: "OrdenadorId");

            migrationBuilder.RenameIndex(
                name: "IX_SolicitudesOrdenador_DispositivoId",
                table: "SolicitudesOrdenador",
                newName: "IX_SolicitudesOrdenador_OrdenadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitudesOrdenador_DispositivosComputacionales_OrdenadorId",
                table: "SolicitudesOrdenador",
                column: "OrdenadorId",
                principalTable: "DispositivosComputacionales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
