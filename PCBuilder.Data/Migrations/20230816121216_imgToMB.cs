using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCBuilder.Data.Migrations
{
    public partial class imgToMB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MotherBoards",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "MotherBoards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "MotherBoards",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://ardes.bg/uploads/original/msi-pro-b650m-a-wifi-am5-423853.jpg");

            migrationBuilder.UpdateData(
                table: "MotherBoards",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://ardes.bg/uploads/original/asus-tuf-gaming-b650-plus-417061.jpg");

            migrationBuilder.UpdateData(
                table: "MotherBoards",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://p1.akcdn.net/full/748039353.gigabyte-b550-aorus-elite-v2.jpg");

            migrationBuilder.UpdateData(
                table: "MotherBoards",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://storage-asset.msi.com/global/picture/image/feature/mb/B550/MAG/TOMAHAWK-MAX-WIFI/msi-mag-b550-tomahawk-max-wifi-hero-board01.png");

            migrationBuilder.UpdateData(
                table: "MotherBoards",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://www.vario.bg/images/product/37965/GIGABYTE%20Z790%20AORUS%20Elite%20AX.jpg");

            migrationBuilder.UpdateData(
                table: "MotherBoards",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://pcbuild.bg/assets/products/000/000/267/000000267208--danna-platka-asus-tuf-gaming-z790-plus-d4-lga1700-ddr4.jpg");

            migrationBuilder.UpdateData(
                table: "PCConfigurations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 16, 15, 12, 15, 743, DateTimeKind.Local).AddTicks(9123));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "MotherBoards");

            migrationBuilder.InsertData(
                table: "MotherBoards",
                columns: new[] { "Id", "BuilderId", "IsDeleted", "Name", "Price", "RamCapacity", "SocketId", "VendorId" },
                values: new object[] { 7, new Guid("00000000-0000-0000-0000-000000000000"), false, "MSI MPG Z490 Gaming Plus", 189.99m, 128, 3, 2 });

            migrationBuilder.UpdateData(
                table: "PCConfigurations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 8, 16, 11, 54, 46, 207, DateTimeKind.Local).AddTicks(9320));
        }
    }
}
