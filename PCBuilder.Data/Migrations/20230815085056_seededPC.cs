using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCBuilder.Data.Migrations
{
    public partial class seededPC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PCConfigurations_Builders_BuilderId1",
                table: "PCConfigurations");

            migrationBuilder.AlterColumn<Guid>(
                name: "BuilderId1",
                table: "PCConfigurations",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "PCConfigurations",
                columns: new[] { "Id", "BidderId", "BuilderId", "BuilderId1", "CPUId", "CaseId", "GraphicsCardId", "HighestBid", "MotherBoardId", "Name", "TotalSystemWattage" },
                values: new object[] { 1, null, new Guid("7131367d-d5ad-4f72-b6f7-703bca071854"), null, 1, 1, 1, 0m, 3, "Gaming PC 1", 650 });

            migrationBuilder.AddForeignKey(
                name: "FK_PCConfigurations_Builders_BuilderId1",
                table: "PCConfigurations",
                column: "BuilderId1",
                principalTable: "Builders",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PCConfigurations_Builders_BuilderId1",
                table: "PCConfigurations");

            migrationBuilder.DeleteData(
                table: "PCConfigurations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<Guid>(
                name: "BuilderId1",
                table: "PCConfigurations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PCConfigurations_Builders_BuilderId1",
                table: "PCConfigurations",
                column: "BuilderId1",
                principalTable: "Builders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
