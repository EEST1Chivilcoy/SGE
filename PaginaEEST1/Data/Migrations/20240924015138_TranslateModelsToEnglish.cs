using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaginaEEST1.Data.Migrations
{
    /// <inheritdoc />
    public partial class TranslateModelsToEnglish : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DispositivosComputacionales_ReservasDeNetbooks_ReservaNetboo~",
                table: "DispositivosComputacionales");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservasDeNetbooks_Personas_AlumnoId",
                table: "ReservasDeNetbooks");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservasDeNetbooks_Personas_ProfesorId",
                table: "ReservasDeNetbooks");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitudesOrdenador_DispositivosComputacionales_Dispositivo~",
                table: "SolicitudesOrdenador");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitudesOrdenador_Personas_ProfesorId",
                table: "SolicitudesOrdenador");

            migrationBuilder.DropIndex(
                name: "IX_SolicitudesOrdenador_ProfesorId",
                table: "SolicitudesOrdenador");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Personas",
                table: "Personas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DispositivosComputacionales",
                table: "DispositivosComputacionales");

            migrationBuilder.DropIndex(
                name: "IX_DispositivosComputacionales_ReservaNetbookId",
                table: "DispositivosComputacionales");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Personas");

            migrationBuilder.RenameTable(
                name: "Personas",
                newName: "People");

            migrationBuilder.RenameTable(
                name: "DispositivosComputacionales",
                newName: "Computers");

            migrationBuilder.RenameColumn(
                name: "VersionPrograma",
                table: "SolicitudesOrdenador",
                newName: "VersionProgram");

            migrationBuilder.RenameColumn(
                name: "Tipo",
                table: "SolicitudesOrdenador",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "ProfesorId",
                table: "SolicitudesOrdenador",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "Prioridad",
                table: "SolicitudesOrdenador",
                newName: "Preority");

            migrationBuilder.RenameColumn(
                name: "NombrePrograma",
                table: "SolicitudesOrdenador",
                newName: "NameProgram");

            migrationBuilder.RenameColumn(
                name: "FechaSolicitud",
                table: "SolicitudesOrdenador",
                newName: "RequestDate");

            migrationBuilder.RenameColumn(
                name: "FechaFinalizacionEstimada",
                table: "SolicitudesOrdenador",
                newName: "RequestStartDate");

            migrationBuilder.RenameColumn(
                name: "Estado",
                table: "SolicitudesOrdenador",
                newName: "ProfessorId");

            migrationBuilder.RenameColumn(
                name: "DispositivoId",
                table: "SolicitudesOrdenador",
                newName: "ComputerId");

            migrationBuilder.RenameColumn(
                name: "DescripcionFallo",
                table: "SolicitudesOrdenador",
                newName: "FailureDescription");

            migrationBuilder.RenameColumn(
                name: "DescripcionCorta",
                table: "SolicitudesOrdenador",
                newName: "ShortDescription");

            migrationBuilder.RenameIndex(
                name: "IX_SolicitudesOrdenador_DispositivoId",
                table: "SolicitudesOrdenador",
                newName: "IX_SolicitudesOrdenador_ComputerId");

            migrationBuilder.RenameColumn(
                name: "ProfesorId",
                table: "ReservasDeNetbooks",
                newName: "ProfessorId");

            migrationBuilder.RenameColumn(
                name: "Materia",
                table: "ReservasDeNetbooks",
                newName: "Subject");

            migrationBuilder.RenameColumn(
                name: "AlumnoId",
                table: "ReservasDeNetbooks",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_ReservasDeNetbooks_ProfesorId",
                table: "ReservasDeNetbooks",
                newName: "IX_ReservasDeNetbooks_ProfessorId");

            migrationBuilder.RenameIndex(
                name: "IX_ReservasDeNetbooks_AlumnoId",
                table: "ReservasDeNetbooks",
                newName: "IX_ReservasDeNetbooks_StudentId");

            migrationBuilder.RenameColumn(
                name: "Turno_Cursada",
                table: "People",
                newName: "Shift");

            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "People",
                newName: "IDCard");

            migrationBuilder.RenameColumn(
                name: "TipoPersona",
                table: "People",
                newName: "TypePerson");

            migrationBuilder.RenameColumn(
                name: "Sexo",
                table: "People",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "People",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "NivelEstudios",
                table: "People",
                newName: "EducationLevel");

            migrationBuilder.RenameColumn(
                name: "FechaNacimiento",
                table: "People",
                newName: "BirthDate");

            migrationBuilder.RenameColumn(
                name: "Documento",
                table: "People",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "Apellido",
                table: "People",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "PersonaId",
                table: "People",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "tipoAlmacenamiento",
                table: "Computers",
                newName: "typeStorage");

            migrationBuilder.RenameColumn(
                name: "Ubicacion",
                table: "Computers",
                newName: "Processor");

            migrationBuilder.RenameColumn(
                name: "TipoOrdenador",
                table: "Computers",
                newName: "typeComputer");

            migrationBuilder.RenameColumn(
                name: "SistemaOperativo",
                table: "Computers",
                newName: "OperatingSystem");

            migrationBuilder.RenameColumn(
                name: "ReservaNetbookId",
                table: "Computers",
                newName: "Storage");

            migrationBuilder.RenameColumn(
                name: "Procesador",
                table: "Computers",
                newName: "Model");

            migrationBuilder.RenameColumn(
                name: "Prestamo",
                table: "Computers",
                newName: "IsAvailable");

            migrationBuilder.RenameColumn(
                name: "NombreOCodigoDispositivo",
                table: "Computers",
                newName: "DeviceName");

            migrationBuilder.RenameColumn(
                name: "Modelo",
                table: "Computers",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "Estado",
                table: "Computers",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "Almacenamiento",
                table: "Computers",
                newName: "NetbookLoanId");

            migrationBuilder.RenameIndex(
                name: "IX_DispositivosComputacionales_NombreOCodigoDispositivo",
                table: "Computers",
                newName: "IX_Computers_DeviceName");

            migrationBuilder.AddColumn<DateTime>(
                name: "EstimatedCompletionDate",
                table: "SolicitudesOrdenador",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_People",
                table: "People",
                column: "PersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Computers",
                table: "Computers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudesOrdenador_ProfessorId",
                table: "SolicitudesOrdenador",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_NetbookLoanId",
                table: "Computers",
                column: "NetbookLoanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_ReservasDeNetbooks_NetbookLoanId",
                table: "Computers",
                column: "NetbookLoanId",
                principalTable: "ReservasDeNetbooks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservasDeNetbooks_People_ProfessorId",
                table: "ReservasDeNetbooks",
                column: "ProfessorId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservasDeNetbooks_People_StudentId",
                table: "ReservasDeNetbooks",
                column: "StudentId",
                principalTable: "People",
                principalColumn: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitudesOrdenador_Computers_ComputerId",
                table: "SolicitudesOrdenador",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitudesOrdenador_People_ProfessorId",
                table: "SolicitudesOrdenador",
                column: "ProfessorId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Computers_ReservasDeNetbooks_NetbookLoanId",
                table: "Computers");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservasDeNetbooks_People_ProfessorId",
                table: "ReservasDeNetbooks");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservasDeNetbooks_People_StudentId",
                table: "ReservasDeNetbooks");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitudesOrdenador_Computers_ComputerId",
                table: "SolicitudesOrdenador");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitudesOrdenador_People_ProfessorId",
                table: "SolicitudesOrdenador");

            migrationBuilder.DropIndex(
                name: "IX_SolicitudesOrdenador_ProfessorId",
                table: "SolicitudesOrdenador");

            migrationBuilder.DropPrimaryKey(
                name: "PK_People",
                table: "People");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Computers",
                table: "Computers");

            migrationBuilder.DropIndex(
                name: "IX_Computers_NetbookLoanId",
                table: "Computers");

            migrationBuilder.DropColumn(
                name: "EstimatedCompletionDate",
                table: "SolicitudesOrdenador");

            migrationBuilder.RenameTable(
                name: "People",
                newName: "Personas");

            migrationBuilder.RenameTable(
                name: "Computers",
                newName: "DispositivosComputacionales");

            migrationBuilder.RenameColumn(
                name: "VersionProgram",
                table: "SolicitudesOrdenador",
                newName: "VersionPrograma");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "SolicitudesOrdenador",
                newName: "Tipo");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "SolicitudesOrdenador",
                newName: "ProfesorId");

            migrationBuilder.RenameColumn(
                name: "ShortDescription",
                table: "SolicitudesOrdenador",
                newName: "DescripcionCorta");

            migrationBuilder.RenameColumn(
                name: "RequestStartDate",
                table: "SolicitudesOrdenador",
                newName: "FechaFinalizacionEstimada");

            migrationBuilder.RenameColumn(
                name: "RequestDate",
                table: "SolicitudesOrdenador",
                newName: "FechaSolicitud");

            migrationBuilder.RenameColumn(
                name: "ProfessorId",
                table: "SolicitudesOrdenador",
                newName: "Estado");

            migrationBuilder.RenameColumn(
                name: "Preority",
                table: "SolicitudesOrdenador",
                newName: "Prioridad");

            migrationBuilder.RenameColumn(
                name: "NameProgram",
                table: "SolicitudesOrdenador",
                newName: "NombrePrograma");

            migrationBuilder.RenameColumn(
                name: "FailureDescription",
                table: "SolicitudesOrdenador",
                newName: "DescripcionFallo");

            migrationBuilder.RenameColumn(
                name: "ComputerId",
                table: "SolicitudesOrdenador",
                newName: "DispositivoId");

            migrationBuilder.RenameIndex(
                name: "IX_SolicitudesOrdenador_ComputerId",
                table: "SolicitudesOrdenador",
                newName: "IX_SolicitudesOrdenador_DispositivoId");

            migrationBuilder.RenameColumn(
                name: "Subject",
                table: "ReservasDeNetbooks",
                newName: "Materia");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "ReservasDeNetbooks",
                newName: "AlumnoId");

            migrationBuilder.RenameColumn(
                name: "ProfessorId",
                table: "ReservasDeNetbooks",
                newName: "ProfesorId");

            migrationBuilder.RenameIndex(
                name: "IX_ReservasDeNetbooks_StudentId",
                table: "ReservasDeNetbooks",
                newName: "IX_ReservasDeNetbooks_AlumnoId");

            migrationBuilder.RenameIndex(
                name: "IX_ReservasDeNetbooks_ProfessorId",
                table: "ReservasDeNetbooks",
                newName: "IX_ReservasDeNetbooks_ProfesorId");

            migrationBuilder.RenameColumn(
                name: "TypePerson",
                table: "Personas",
                newName: "TipoPersona");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Personas",
                newName: "Sexo");

            migrationBuilder.RenameColumn(
                name: "Shift",
                table: "Personas",
                newName: "Turno_Cursada");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Personas",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "IDCard",
                table: "Personas",
                newName: "Titulo");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Personas",
                newName: "Apellido");

            migrationBuilder.RenameColumn(
                name: "EducationLevel",
                table: "Personas",
                newName: "NivelEstudios");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "Personas",
                newName: "FechaNacimiento");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Personas",
                newName: "Documento");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Personas",
                newName: "PersonaId");

            migrationBuilder.RenameColumn(
                name: "typeStorage",
                table: "DispositivosComputacionales",
                newName: "tipoAlmacenamiento");

            migrationBuilder.RenameColumn(
                name: "typeComputer",
                table: "DispositivosComputacionales",
                newName: "TipoOrdenador");

            migrationBuilder.RenameColumn(
                name: "Storage",
                table: "DispositivosComputacionales",
                newName: "ReservaNetbookId");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "DispositivosComputacionales",
                newName: "Estado");

            migrationBuilder.RenameColumn(
                name: "Processor",
                table: "DispositivosComputacionales",
                newName: "Ubicacion");

            migrationBuilder.RenameColumn(
                name: "OperatingSystem",
                table: "DispositivosComputacionales",
                newName: "SistemaOperativo");

            migrationBuilder.RenameColumn(
                name: "NetbookLoanId",
                table: "DispositivosComputacionales",
                newName: "Almacenamiento");

            migrationBuilder.RenameColumn(
                name: "Model",
                table: "DispositivosComputacionales",
                newName: "Procesador");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "DispositivosComputacionales",
                newName: "Modelo");

            migrationBuilder.RenameColumn(
                name: "IsAvailable",
                table: "DispositivosComputacionales",
                newName: "Prestamo");

            migrationBuilder.RenameColumn(
                name: "DeviceName",
                table: "DispositivosComputacionales",
                newName: "NombreOCodigoDispositivo");

            migrationBuilder.RenameIndex(
                name: "IX_Computers_DeviceName",
                table: "DispositivosComputacionales",
                newName: "IX_DispositivosComputacionales_NombreOCodigoDispositivo");

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Personas",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Personas",
                table: "Personas",
                column: "PersonaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DispositivosComputacionales",
                table: "DispositivosComputacionales",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudesOrdenador_ProfesorId",
                table: "SolicitudesOrdenador",
                column: "ProfesorId");

            migrationBuilder.CreateIndex(
                name: "IX_DispositivosComputacionales_ReservaNetbookId",
                table: "DispositivosComputacionales",
                column: "ReservaNetbookId");

            migrationBuilder.AddForeignKey(
                name: "FK_DispositivosComputacionales_ReservasDeNetbooks_ReservaNetboo~",
                table: "DispositivosComputacionales",
                column: "ReservaNetbookId",
                principalTable: "ReservasDeNetbooks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservasDeNetbooks_Personas_AlumnoId",
                table: "ReservasDeNetbooks",
                column: "AlumnoId",
                principalTable: "Personas",
                principalColumn: "PersonaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservasDeNetbooks_Personas_ProfesorId",
                table: "ReservasDeNetbooks",
                column: "ProfesorId",
                principalTable: "Personas",
                principalColumn: "PersonaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitudesOrdenador_DispositivosComputacionales_Dispositivo~",
                table: "SolicitudesOrdenador",
                column: "DispositivoId",
                principalTable: "DispositivosComputacionales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitudesOrdenador_Personas_ProfesorId",
                table: "SolicitudesOrdenador",
                column: "ProfesorId",
                principalTable: "Personas",
                principalColumn: "PersonaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
