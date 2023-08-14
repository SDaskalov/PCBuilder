using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCBuilder.Data.Migrations
{
    public partial class seedvendors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CPUVendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "AMD" });

            migrationBuilder.InsertData(
                table: "CPUVendors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "INTEL" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CPUVendors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CPUVendors",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
