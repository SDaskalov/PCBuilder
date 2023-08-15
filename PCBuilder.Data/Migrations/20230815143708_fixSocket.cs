using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCBuilder.Data.Migrations
{
    public partial class fixSocket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PCConfigurations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 15, 17, 37, 7, 658, DateTimeKind.Local).AddTicks(4762));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PCConfigurations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 15, 15, 37, 54, 706, DateTimeKind.Local).AddTicks(9594));
        }
    }
}
