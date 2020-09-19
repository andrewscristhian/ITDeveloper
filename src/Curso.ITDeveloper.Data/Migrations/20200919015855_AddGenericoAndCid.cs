﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Curso.ITDeveloper.Data.Migrations
{
    public partial class AddGenericoAndCid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cid",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CidInternalId = table.Column<int>(nullable: false),
                    Codigo = table.Column<string>(type: "varchar(90)", maxLength: 6, nullable: false),
                    Diagnostico = table.Column<string>(type: "varchar(90)", maxLength: 4000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cid", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Generico",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Codigo = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(90)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generico", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cid");

            migrationBuilder.DropTable(
                name: "Generico");
        }
    }
}
