using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Curso.ITDeveloper.Data.Migrations
{
    public partial class AddFieldIdEstadoPaciente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EstadoPacienteId",
                table: "Paciente",
                nullable: false,
                defaultValue: new Guid("de2f8d71-246a-431c-8851-4023e7b562d4"));

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_EstadoPacienteId",
                table: "Paciente",
                column: "EstadoPacienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Paciente_EstadoPaciente_EstadoPacienteId",
                table: "Paciente",
                column: "EstadoPacienteId",
                principalTable: "EstadoPaciente",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paciente_EstadoPaciente_EstadoPacienteId",
                table: "Paciente");

            migrationBuilder.DropIndex(
                name: "IX_Paciente_EstadoPacienteId",
                table: "Paciente");

            migrationBuilder.DropColumn(
                name: "EstadoPacienteId",
                table: "Paciente");
        }
    }
}
