using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Curso.ITDeveloper.Data.Migrations
{
    public partial class AddMappingEstadoPacienteEPacienteMapApplyAll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paciente_EstadoPaciente_EstadoPacienteId",
                table: "Paciente");

            migrationBuilder.AlterColumn<string>(
                name: "RgOrgao",
                table: "Paciente",
                type: "varchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Rg",
                table: "Paciente",
                type: "varchar(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Paciente",
                type: "varchar(80)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Paciente",
                type: "varchar(150)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Paciente",
                type: "varchar(11)",
                fixedLength: true,
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Mural",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Mural",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Aviso",
                table: "Mural",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Autor",
                table: "Mural",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "EstadoPaciente",
                type: "varchar(30)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.CreateTable(
                name: "MovimentoPaciente",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimentoPaciente", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Paciente_EstadoPaciente_EstadoPacienteId",
                table: "Paciente",
                column: "EstadoPacienteId",
                principalTable: "EstadoPaciente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paciente_EstadoPaciente_EstadoPacienteId",
                table: "Paciente");

            migrationBuilder.DropTable(
                name: "MovimentoPaciente");

            migrationBuilder.AlterColumn<string>(
                name: "RgOrgao",
                table: "Paciente",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Rg",
                table: "Paciente",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Paciente",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(80)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Paciente",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Paciente",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(11)",
                oldFixedLength: true,
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Mural",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Mural",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Aviso",
                table: "Mural",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Autor",
                table: "Mural",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "EstadoPaciente",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 20);

            migrationBuilder.AddForeignKey(
                name: "FK_Paciente_EstadoPaciente_EstadoPacienteId",
                table: "Paciente",
                column: "EstadoPacienteId",
                principalTable: "EstadoPaciente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
