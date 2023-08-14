using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCBuilder.Data.Migrations
{
    public partial class updateMB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MotherBoards_CPUs_CpuId",
                table: "MotherBoards");

            migrationBuilder.RenameColumn(
                name: "CpuId",
                table: "MotherBoards",
                newName: "SocketId");

            migrationBuilder.RenameIndex(
                name: "IX_MotherBoards_CpuId",
                table: "MotherBoards",
                newName: "IX_MotherBoards_SocketId");

            migrationBuilder.AddForeignKey(
                name: "FK_MotherBoards_Socket_SocketId",
                table: "MotherBoards",
                column: "SocketId",
                principalTable: "Socket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MotherBoards_Socket_SocketId",
                table: "MotherBoards");

            migrationBuilder.RenameColumn(
                name: "SocketId",
                table: "MotherBoards",
                newName: "CpuId");

            migrationBuilder.RenameIndex(
                name: "IX_MotherBoards_SocketId",
                table: "MotherBoards",
                newName: "IX_MotherBoards_CpuId");

            migrationBuilder.AddForeignKey(
                name: "FK_MotherBoards_CPUs_CpuId",
                table: "MotherBoards",
                column: "CpuId",
                principalTable: "CPUs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
