using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCBuilder.Data.Migrations
{
    public partial class rangeCPU : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ModelName",
                table: "CPUs",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "PCConfigurations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 15, 15, 37, 54, 706, DateTimeKind.Local).AddTicks(9594));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ModelName",
                table: "CPUs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                table: "PCConfigurations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 15, 12, 4, 14, 207, DateTimeKind.Local).AddTicks(6564));
        }
    }
}
