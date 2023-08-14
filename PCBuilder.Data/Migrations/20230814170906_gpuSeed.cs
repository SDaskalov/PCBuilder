using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCBuilder.Data.Migrations
{
    public partial class gpuSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "GraphicsCards",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "GraphicsCards",
                columns: new[] { "Id", "ImageURL", "MaxWattage", "ModelName", "Price" },
                values: new object[,]
                {
                    { 1, "https://p1.akcdn.net/full/744790884.gigabyte-geforce-rtx-3070-8gb-gddr6-256bit-gv-n3070gaming-oc-8gd.jpg", 220, "GeForce RTX 3070", 599.99m },
                    { 2, "https://p1.akcdn.net/full/1122500418.asus-geforce-rtx-4090-oc-24gb-gddr6x-rog-strix-rtx4090-o24g-gaming.jpg", 400, "GeForce RTX 4090", 1599.00m },
                    { 3, "https://pg.asrock.com/Graphics-Card/photo/Radeon%20RX%207900%20XTX%20Phantom%20Gaming%2024GB%20OC(L1).png", 355, "AMD RX 7900XTX", 999.99m },
                    { 4, "https://cdna.pcpartpicker.com/static/forever/images/product/5199e776d5e1c9d319b4a275139bbcf4.1600.jpg", 335, "AMD RX 6950XT", 649.99m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GraphicsCards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GraphicsCards",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GraphicsCards",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "GraphicsCards",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Price",
                table: "GraphicsCards");
        }
    }
}
