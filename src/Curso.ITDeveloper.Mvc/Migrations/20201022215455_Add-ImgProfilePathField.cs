﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Curso.ITDeveloper.Mvc.Migrations
{
    public partial class AddImgProfilePathField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgProfilePath",
                table: "AspNetUsers",
                maxLength: 255,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgProfilePath",
                table: "AspNetUsers");
        }
    }
}
