﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Curso.ITDeveloper.Data.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstadoPaciente",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar(30)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoPaciente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mural",
                columns: table => new
                {
                    MuralId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(nullable: false),
                    Titulo = table.Column<string>(type: "varchar(90)", nullable: true),
                    Aviso = table.Column<string>(type: "varchar(90)", nullable: true),
                    Autor = table.Column<string>(type: "varchar(90)", nullable: true),
                    Email = table.Column<string>(type: "varchar(90)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mural", x => x.MuralId);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(80)", nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    DataInternacao = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(type: "varchar(150)", nullable: true),
                    Ativo = table.Column<bool>(nullable: false),
                    Cpf = table.Column<string>(type: "varchar(11)", fixedLength: true, maxLength: 11, nullable: true),
                    TipoPaciente = table.Column<int>(nullable: false),
                    Sexo = table.Column<int>(nullable: false),
                    Rg = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    RgOrgao = table.Column<string>(type: "varchar(10)", nullable: true),
                    RgDataEmissao = table.Column<DateTime>(nullable: false),
                    EstadoPacienteId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paciente_EstadoPaciente_EstadoPacienteId",
                        column: x => x.EstadoPacienteId,
                        principalTable: "EstadoPaciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_EstadoPacienteId",
                table: "Paciente",
                column: "EstadoPacienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mural");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "EstadoPaciente");
        }
    }
}
