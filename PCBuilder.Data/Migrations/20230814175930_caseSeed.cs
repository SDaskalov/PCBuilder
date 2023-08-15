using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCBuilder.Data.Migrations
{
    public partial class caseSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ComputerCases",
                columns: new[] { "Id", "ImageUrl", "Name", "Price" },
                values: new object[] { 1, "https://www.altech.bg/files/products/118756.jpg", "Fractal Design North", 180.00m });

            migrationBuilder.InsertData(
                table: "ComputerCases",
                columns: new[] { "Id", "ImageUrl", "Name", "Price" },
                values: new object[] { 2, "https://images10.newegg.com/BizIntell/item/Case/Cases%20(Computer%20Cases%20-%20ATX%20Form)/2AM-000Z-000A9/1.jpg", "Lian Li Lancool 216", 119.99m });

            migrationBuilder.InsertData(
                table: "ComputerCases",
                columns: new[] { "Id", "ImageUrl", "Name", "Price" },
                values: new object[] { 3, "https://www.pro-bg.com/resize_image_max/800/600/FRACTAL%20DESIGN/Computer-Case-FractalDesign-TORRENT-BLACK-SOLID.jpeg", "Fractal Design Torrent", 199.99m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ComputerCases",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ComputerCases",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ComputerCases",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
