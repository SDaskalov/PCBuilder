using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCBuilder.Data.Migrations
{
    public partial class fixSocketagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CPUs_CpuVendor_VendorId",
                table: "CPUs");

            migrationBuilder.DropForeignKey(
                name: "FK_MotherBoards_CpuVendor_VendorId",
                table: "MotherBoards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CpuVendor",
                table: "CpuVendor");

            migrationBuilder.RenameTable(
                name: "CpuVendor",
                newName: "CPUVendors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CPUVendors",
                table: "CPUVendors",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "PCConfigurations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 15, 17, 39, 41, 992, DateTimeKind.Local).AddTicks(2347));

            migrationBuilder.AddForeignKey(
                name: "FK_CPUs_CPUVendors_VendorId",
                table: "CPUs",
                column: "VendorId",
                principalTable: "CPUVendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MotherBoards_CPUVendors_VendorId",
                table: "MotherBoards",
                column: "VendorId",
                principalTable: "CPUVendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CPUs_CPUVendors_VendorId",
                table: "CPUs");

            migrationBuilder.DropForeignKey(
                name: "FK_MotherBoards_CPUVendors_VendorId",
                table: "MotherBoards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CPUVendors",
                table: "CPUVendors");

            migrationBuilder.RenameTable(
                name: "CPUVendors",
                newName: "CpuVendor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CpuVendor",
                table: "CpuVendor",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "PCConfigurations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 15, 17, 37, 7, 658, DateTimeKind.Local).AddTicks(4762));

            migrationBuilder.AddForeignKey(
                name: "FK_CPUs_CpuVendor_VendorId",
                table: "CPUs",
                column: "VendorId",
                principalTable: "CpuVendor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MotherBoards_CpuVendor_VendorId",
                table: "MotherBoards",
                column: "VendorId",
                principalTable: "CpuVendor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
