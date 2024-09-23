using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaginaEEST1.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeModelNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ordenadores_ReservasDeNetbooks_ReservaNetbookId",
                table: "Ordenadores");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitudesOrdenador_Ordenadores_OrdenadorId",
                table: "SolicitudesOrdenador");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ordenadores",
                table: "Ordenadores");

            migrationBuilder.RenameTable(
                name: "Ordenadores",
                newName: "DispositivosComputacionales");

            migrationBuilder.RenameColumn(
                name: "NombreOrdenador",
                table: "DispositivosComputacionales",
                newName: "NombreOCodigoDispositivo");

            migrationBuilder.RenameColumn(
                name: "OrdenadorId",
                table: "DispositivosComputacionales",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Ordenadores_ReservaNetbookId",
                table: "DispositivosComputacionales",
                newName: "IX_DispositivosComputacionales_ReservaNetbookId");

            migrationBuilder.RenameIndex(
                name: "IX_Ordenadores_NombreOrdenador",
                table: "DispositivosComputacionales",
                newName: "IX_DispositivosComputacionales_NombreOCodigoDispositivo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DispositivosComputacionales",
                table: "DispositivosComputacionales",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DispositivosComputacionales_ReservasDeNetbooks_ReservaNetboo~",
                table: "DispositivosComputacionales",
                column: "ReservaNetbookId",
                principalTable: "ReservasDeNetbooks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitudesOrdenador_DispositivosComputacionales_OrdenadorId",
                table: "SolicitudesOrdenador",
                column: "OrdenadorId",
                principalTable: "DispositivosComputacionales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DispositivosComputacionales_ReservasDeNetbooks_ReservaNetboo~",
                table: "DispositivosComputacionales");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitudesOrdenador_DispositivosComputacionales_OrdenadorId",
                table: "SolicitudesOrdenador");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DispositivosComputacionales",
                table: "DispositivosComputacionales");

            migrationBuilder.RenameTable(
                name: "DispositivosComputacionales",
                newName: "Ordenadores");

            migrationBuilder.RenameColumn(
                name: "NombreOCodigoDispositivo",
                table: "Ordenadores",
                newName: "NombreOrdenador");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Ordenadores",
                newName: "OrdenadorId");

            migrationBuilder.RenameIndex(
                name: "IX_DispositivosComputacionales_ReservaNetbookId",
                table: "Ordenadores",
                newName: "IX_Ordenadores_ReservaNetbookId");

            migrationBuilder.RenameIndex(
                name: "IX_DispositivosComputacionales_NombreOCodigoDispositivo",
                table: "Ordenadores",
                newName: "IX_Ordenadores_NombreOrdenador");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ordenadores",
                table: "Ordenadores",
                column: "OrdenadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ordenadores_ReservasDeNetbooks_ReservaNetbookId",
                table: "Ordenadores",
                column: "ReservaNetbookId",
                principalTable: "ReservasDeNetbooks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitudesOrdenador_Ordenadores_OrdenadorId",
                table: "SolicitudesOrdenador",
                column: "OrdenadorId",
                principalTable: "Ordenadores",
                principalColumn: "OrdenadorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
