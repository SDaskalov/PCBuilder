using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCBuilder.Data.Migrations
{
    public partial class mbSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MotherBoards",
                columns: new[] { "Id", "Name", "Price", "RamCapacity", "SocketId", "VendorId" },
                values: new object[,]
                {
                    { 1, "MSI PRO B650M-A WIFI", 199.99m, 128, 2, 1 },
                    { 2, "ASUS TUF GAMING B650-PLUS", 228.99m, 128, 2, 1 },
                    { 3, "GIGABYTE B550 AORUS ELITE V2", 189.99m, 128, 1, 1 },
                    { 4, "MSI MAG B550 Tomahawk", 150.00m, 256, 1, 1 },
                    { 5, "Gigabyte Motherboard Z790 AORUS ELITE AX", 299.99m, 256, 4, 2 },
                    { 6, "ASUS TUF GAMING Z790-PLUS WIFI D4 ", 249.99m, 256, 4, 2 },
                    { 7, "MSI MPG Z490 Gaming Plus", 189.99m, 128, 3, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MotherBoards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MotherBoards",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MotherBoards",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MotherBoards",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MotherBoards",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MotherBoards",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MotherBoards",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
