using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCBuilder.Data.Migrations
{
    public partial class addedBuilder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BuilderId",
                table: "MotherBoards",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MotherBoards",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "BuilderId",
                table: "GraphicsCards",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "GraphicsCards",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "BuilderId",
                table: "CPUs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "BuilderId",
                table: "ComputerCases",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ComputerCases",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "PCConfigurations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 16, 11, 54, 46, 207, DateTimeKind.Local).AddTicks(9320));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuilderId",
                table: "MotherBoards");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MotherBoards");

            migrationBuilder.DropColumn(
                name: "BuilderId",
                table: "GraphicsCards");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "GraphicsCards");

            migrationBuilder.DropColumn(
                name: "BuilderId",
                table: "CPUs");

            migrationBuilder.DropColumn(
                name: "BuilderId",
                table: "ComputerCases");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ComputerCases");

            migrationBuilder.UpdateData(
                table: "PCConfigurations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 16, 11, 28, 26, 109, DateTimeKind.Local).AddTicks(8457));
        }
    }
}
