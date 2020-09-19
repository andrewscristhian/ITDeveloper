using Microsoft.EntityFrameworkCore.Migrations;

namespace Curso.ITDeveloper.Data.Migrations
{
    public partial class AddCid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Diagnostico",
                table: "Cid",
                type: "nvarchar(4000)",
                maxLength: 4000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(90)",
                oldMaxLength: 4000);

            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "Cid",
                type: "varchar(6)",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(90)",
                oldMaxLength: 6);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Diagnostico",
                table: "Cid",
                type: "varchar(90)",
                maxLength: 4000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)",
                oldMaxLength: 4000);

            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "Cid",
                type: "varchar(90)",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(6)",
                oldMaxLength: 6);
        }
    }
}
