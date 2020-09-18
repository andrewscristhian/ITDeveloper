using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Curso.ITDeveloper.Mvc.Migrations
{
    public partial class AddNewUserAndRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B8741F07-94B4-484A-B561-D3EFE1451915",
                column: "ConcurrencyStamp",
                value: "eda2a633-2422-4392-8cdc-c6568fa2aee5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BA59D53A-32CE-435B-A964-23D0414D115B",
                columns: new[] { "ConcurrencyStamp", "DataNascimento", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7c1fcbe2-48a7-45d8-97eb-d99626489363", new DateTime(2020, 9, 17, 23, 33, 4, 10, DateTimeKind.Local).AddTicks(2019), "AQAAAAEAACcQAAAAEAiM8ZcJ0QV1mg9s0KL4/6aAupcN23323U+Qw6tCu/4G0RszrDPm8BkCjWp7S1Xtbg==", "f9413cf7-bade-4a4f-89fd-ce75143c4724" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B8741F07-94B4-484A-B561-D3EFE1451915",
                column: "ConcurrencyStamp",
                value: "8039cd58-245f-4dce-b6ee-0ed0f1b20b97");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BA59D53A-32CE-435B-A964-23D0414D115B",
                columns: new[] { "ConcurrencyStamp", "DataNascimento", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3dc60de7-923d-40db-a729-51f4c1848ff4", new DateTime(2020, 9, 17, 23, 12, 34, 918, DateTimeKind.Local).AddTicks(3830), "AQAAAAEAACcQAAAAECtjwgTJvsRtv6+BfINXXb2EIOvysANSSf6DVPsoFQ1I7HK2qRtc3beOhNtWZ86U7w==", "1a5a1b83-b105-4f8f-8ce8-474878f0e4ca" });
        }
    }
}
