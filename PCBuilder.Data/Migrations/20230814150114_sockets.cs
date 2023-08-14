using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCBuilder.Data.Migrations
{
    public partial class sockets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CPUs_CPUVendors_VendorId",
                table: "CPUs");

            migrationBuilder.DropForeignKey(
                name: "FK_CPUs_Sockets_SocketId",
                table: "CPUs");

            migrationBuilder.DropForeignKey(
                name: "FK_MotherBoards_CPUVendors_VendorId",
                table: "MotherBoards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sockets",
                table: "Sockets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CPUVendors",
                table: "CPUVendors");

            migrationBuilder.RenameTable(
                name: "Sockets",
                newName: "Socket");

            migrationBuilder.RenameTable(
                name: "CPUVendors",
                newName: "CpuVendor");

            migrationBuilder.AlterColumn<int>(
                name: "SocketId",
                table: "CPUs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Socket",
                table: "Socket",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CpuVendor",
                table: "CpuVendor",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Socket",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "AM4" },
                    { 2, "AM5" },
                    { 3, "LGA1200" },
                    { 4, "LGA1700" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CPUs_CpuVendor_VendorId",
                table: "CPUs",
                column: "VendorId",
                principalTable: "CpuVendor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CPUs_Socket_SocketId",
                table: "CPUs",
                column: "SocketId",
                principalTable: "Socket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MotherBoards_CpuVendor_VendorId",
                table: "MotherBoards",
                column: "VendorId",
                principalTable: "CpuVendor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CPUs_CpuVendor_VendorId",
                table: "CPUs");

            migrationBuilder.DropForeignKey(
                name: "FK_CPUs_Socket_SocketId",
                table: "CPUs");

            migrationBuilder.DropForeignKey(
                name: "FK_MotherBoards_CpuVendor_VendorId",
                table: "MotherBoards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Socket",
                table: "Socket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CpuVendor",
                table: "CpuVendor");

            migrationBuilder.DeleteData(
                table: "Socket",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Socket",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Socket",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Socket",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.RenameTable(
                name: "Socket",
                newName: "Sockets");

            migrationBuilder.RenameTable(
                name: "CpuVendor",
                newName: "CPUVendors");

            migrationBuilder.AlterColumn<int>(
                name: "SocketId",
                table: "CPUs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sockets",
                table: "Sockets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CPUVendors",
                table: "CPUVendors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CPUs_CPUVendors_VendorId",
                table: "CPUs",
                column: "VendorId",
                principalTable: "CPUVendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CPUs_Sockets_SocketId",
                table: "CPUs",
                column: "SocketId",
                principalTable: "Sockets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MotherBoards_CPUVendors_VendorId",
                table: "MotherBoards",
                column: "VendorId",
                principalTable: "CPUVendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
