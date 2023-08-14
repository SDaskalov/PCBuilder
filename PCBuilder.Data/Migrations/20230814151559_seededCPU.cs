using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCBuilder.Data.Migrations
{
    public partial class seededCPU : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CPUs",
                columns: new[] { "Id", "IntegratedGraphics", "MaxWattage", "ModelName", "Price", "SocketId", "VendorId" },
                values: new object[,]
                {
                    { 1, false, 95, "Ryzen 9 5900x", 450.00m, 1, 1 },
                    { 2, true, 105, "Ryzen 7 7700x", 550.00m, 2, 1 },
                    { 3, true, 105, "Intel Core i7-13700", 550.00m, 4, 2 },
                    { 4, false, 125, "Intel Core i9-11900KF", 990.00m, 3, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CPUs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CPUs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CPUs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CPUs",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
