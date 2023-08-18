using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCBuilder.Data.Migrations
{
    public partial class initiaal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComputerCases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BuilderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerCases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CPUVendors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPUVendors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GraphicsCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxWattage = table.Column<int>(type: "int", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BuilderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GraphicsCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Socket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Socket", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Builders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PublicBuilderName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Builders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Builders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CPUs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SocketId = table.Column<int>(type: "int", nullable: false),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    IntegratedGraphics = table.Column<bool>(type: "bit", nullable: false),
                    MaxWattage = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    BuilderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPUs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CPUs_CPUVendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "CPUVendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CPUs_Socket_SocketId",
                        column: x => x.SocketId,
                        principalTable: "Socket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MotherBoards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    SocketId = table.Column<int>(type: "int", nullable: false),
                    RamCapacity = table.Column<int>(type: "int", nullable: false),
                    BuilderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotherBoards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MotherBoards_CPUVendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "CPUVendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MotherBoards_Socket_SocketId",
                        column: x => x.SocketId,
                        principalTable: "Socket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PCConfigurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherBoardId = table.Column<int>(type: "int", nullable: false),
                    CPUId = table.Column<int>(type: "int", nullable: false),
                    GraphicsCardId = table.Column<int>(type: "int", nullable: true),
                    CaseId = table.Column<int>(type: "int", nullable: false),
                    TotalSystemWattage = table.Column<int>(type: "int", nullable: false),
                    BuilderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HighestBid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BidderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsSold = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    BuilderId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PCConfigurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PCConfigurations_AspNetUsers_BidderId",
                        column: x => x.BidderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PCConfigurations_Builders_BuilderId",
                        column: x => x.BuilderId,
                        principalTable: "Builders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PCConfigurations_Builders_BuilderId1",
                        column: x => x.BuilderId1,
                        principalTable: "Builders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PCConfigurations_ComputerCases_CaseId",
                        column: x => x.CaseId,
                        principalTable: "ComputerCases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PCConfigurations_CPUs_CPUId",
                        column: x => x.CPUId,
                        principalTable: "CPUs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PCConfigurations_GraphicsCards_GraphicsCardId",
                        column: x => x.GraphicsCardId,
                        principalTable: "GraphicsCards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PCConfigurations_MotherBoards_MotherBoardId",
                        column: x => x.MotherBoardId,
                        principalTable: "MotherBoards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("064d17f8-f2be-4be9-8f55-c75e58470edc"), 0, "aa4f4ee3-5afc-452a-9adb-ed9a042be311", "Administrator@PCBuild.com", false, true, null, "Administrator@PCBuild.com", "Administrator@PCBuild.com", "AQAAAAEAACcQAAAAEB4iohEn/AyAuxhV2+hEs++QvIdV6NMWD0K+kpAZMTiK42jug7QyJurVg4MFOEJxFg==", null, false, "I4C5JH3PX7ZFMSOY5OUZOENYUCQWEM7S", false, "Administrator@PCBuild.com" },
                    { new Guid("7131367d-d5ad-4f72-b6f7-703bca071854"), 0, "881c98c0-da7d-4280-a96b-58a30ae3dda9", "test@te.ss", false, true, null, "test@te.ss", "test@te.ss", "AQAAAAEAACcQAAAAEIeL1ThpbFZgGCQy+W3bwMXEzGyQJJITuh2tjLMf748mycXZ4ksWgIeBYDSUUais/w==", null, false, "DTUQGIYIXDCNF6ENNSIM7RLNJCLXL4N7", false, "test@te.ss" }
                });

            migrationBuilder.InsertData(
                table: "CPUVendors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "AMD" },
                    { 2, "INTEL" }
                });

            migrationBuilder.InsertData(
                table: "ComputerCases",
                columns: new[] { "Id", "BuilderId", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, new Guid("00000000-0000-0000-0000-000000000000"), "https://www.altech.bg/files/products/118756.jpg", "Fractal Design North", 180.00m },
                    { 2, new Guid("00000000-0000-0000-0000-000000000000"), "https://images10.newegg.com/BizIntell/item/Case/Cases%20(Computer%20Cases%20-%20ATX%20Form)/2AM-000Z-000A9/1.jpg", "Lian Li Lancool 216", 119.99m },
                    { 3, new Guid("00000000-0000-0000-0000-000000000000"), "https://www.pro-bg.com/resize_image_max/800/600/FRACTAL%20DESIGN/Computer-Case-FractalDesign-TORRENT-BLACK-SOLID.jpeg", "Fractal Design Torrent", 199.99m }
                });

            migrationBuilder.InsertData(
                table: "GraphicsCards",
                columns: new[] { "Id", "BuilderId", "ImageURL", "MaxWattage", "ModelName", "Price" },
                values: new object[,]
                {
                    { 1, new Guid("00000000-0000-0000-0000-000000000000"), "https://p1.akcdn.net/full/744790884.gigabyte-geforce-rtx-3070-8gb-gddr6-256bit-gv-n3070gaming-oc-8gd.jpg", 220, "GeForce RTX 3070", 599.99m },
                    { 2, new Guid("00000000-0000-0000-0000-000000000000"), "https://p1.akcdn.net/full/1122500418.asus-geforce-rtx-4090-oc-24gb-gddr6x-rog-strix-rtx4090-o24g-gaming.jpg", 400, "GeForce RTX 4090", 1599.00m },
                    { 3, new Guid("00000000-0000-0000-0000-000000000000"), "https://pg.asrock.com/Graphics-Card/photo/Radeon%20RX%207900%20XTX%20Phantom%20Gaming%2024GB%20OC(L1).png", 355, "AMD RX 7900XTX", 999.99m },
                    { 4, new Guid("00000000-0000-0000-0000-000000000000"), "https://cdna.pcpartpicker.com/static/forever/images/product/5199e776d5e1c9d319b4a275139bbcf4.1600.jpg", 335, "AMD RX 6950XT", 649.99m }
                });

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

            migrationBuilder.InsertData(
                table: "Builders",
                columns: new[] { "Id", "PublicBuilderName", "UserId" },
                values: new object[] { new Guid("7131367d-d5ad-4f72-b6f7-703bca071854"), "SEEEDBUILDER NAME", new Guid("7131367d-d5ad-4f72-b6f7-703bca071854") });

            migrationBuilder.InsertData(
                table: "CPUs",
                columns: new[] { "Id", "BuilderId", "IntegratedGraphics", "MaxWattage", "ModelName", "Price", "SocketId", "VendorId" },
                values: new object[,]
                {
                    { 1, new Guid("00000000-0000-0000-0000-000000000000"), false, 95, "Ryzen 9 5900x", 450.00m, 1, 1 },
                    { 2, new Guid("00000000-0000-0000-0000-000000000000"), true, 105, "Ryzen 7 7700x", 550.00m, 2, 1 },
                    { 3, new Guid("00000000-0000-0000-0000-000000000000"), true, 105, "Intel Core i7-13700", 550.00m, 4, 2 },
                    { 4, new Guid("00000000-0000-0000-0000-000000000000"), false, 125, "Intel Core i9-11900KF", 990.00m, 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "MotherBoards",
                columns: new[] { "Id", "BuilderId", "ImageUrl", "Name", "Price", "RamCapacity", "SocketId", "VendorId" },
                values: new object[,]
                {
                    { 1, new Guid("00000000-0000-0000-0000-000000000000"), "https://ardes.bg/uploads/original/msi-pro-b650m-a-wifi-am5-423853.jpg", "MSI PRO B650M-A WIFI", 199.99m, 128, 2, 1 },
                    { 2, new Guid("00000000-0000-0000-0000-000000000000"), "https://ardes.bg/uploads/original/asus-tuf-gaming-b650-plus-417061.jpg", "ASUS TUF GAMING B650-PLUS", 228.99m, 128, 2, 1 },
                    { 3, new Guid("00000000-0000-0000-0000-000000000000"), "https://p1.akcdn.net/full/748039353.gigabyte-b550-aorus-elite-v2.jpg", "GIGABYTE B550 AORUS ELITE V2", 189.99m, 128, 1, 1 },
                    { 4, new Guid("00000000-0000-0000-0000-000000000000"), "https://storage-asset.msi.com/global/picture/image/feature/mb/B550/MAG/TOMAHAWK-MAX-WIFI/msi-mag-b550-tomahawk-max-wifi-hero-board01.png", "MSI MAG B550 Tomahawk", 150.00m, 256, 1, 1 },
                    { 5, new Guid("00000000-0000-0000-0000-000000000000"), "https://www.vario.bg/images/product/37965/GIGABYTE%20Z790%20AORUS%20Elite%20AX.jpg", "Gigabyte Motherboard Z790 AORUS ELITE AX", 299.99m, 256, 4, 2 },
                    { 6, new Guid("00000000-0000-0000-0000-000000000000"), "https://pcbuild.bg/assets/products/000/000/267/000000267208--danna-platka-asus-tuf-gaming-z790-plus-d4-lga1700-ddr4.jpg", "ASUS TUF GAMING Z790-PLUS WIFI D4 ", 249.99m, 256, 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "PCConfigurations",
                columns: new[] { "Id", "BidderId", "BuilderId", "BuilderId1", "CPUId", "CaseId", "CreatedOn", "GraphicsCardId", "HighestBid", "MotherBoardId", "Name", "TotalSystemWattage" },
                values: new object[] { 1, null, new Guid("7131367d-d5ad-4f72-b6f7-703bca071854"), null, 1, 1, new DateTime(2023, 8, 18, 17, 8, 22, 480, DateTimeKind.Local).AddTicks(5651), 1, 1200m, 3, "Gaming PC 1", 650 });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Builders_UserId",
                table: "Builders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CPUs_SocketId",
                table: "CPUs",
                column: "SocketId");

            migrationBuilder.CreateIndex(
                name: "IX_CPUs_VendorId",
                table: "CPUs",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_MotherBoards_SocketId",
                table: "MotherBoards",
                column: "SocketId");

            migrationBuilder.CreateIndex(
                name: "IX_MotherBoards_VendorId",
                table: "MotherBoards",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_PCConfigurations_BidderId",
                table: "PCConfigurations",
                column: "BidderId");

            migrationBuilder.CreateIndex(
                name: "IX_PCConfigurations_BuilderId",
                table: "PCConfigurations",
                column: "BuilderId");

            migrationBuilder.CreateIndex(
                name: "IX_PCConfigurations_BuilderId1",
                table: "PCConfigurations",
                column: "BuilderId1");

            migrationBuilder.CreateIndex(
                name: "IX_PCConfigurations_CaseId",
                table: "PCConfigurations",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_PCConfigurations_CPUId",
                table: "PCConfigurations",
                column: "CPUId");

            migrationBuilder.CreateIndex(
                name: "IX_PCConfigurations_GraphicsCardId",
                table: "PCConfigurations",
                column: "GraphicsCardId");

            migrationBuilder.CreateIndex(
                name: "IX_PCConfigurations_MotherBoardId",
                table: "PCConfigurations",
                column: "MotherBoardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "PCConfigurations");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Builders");

            migrationBuilder.DropTable(
                name: "ComputerCases");

            migrationBuilder.DropTable(
                name: "CPUs");

            migrationBuilder.DropTable(
                name: "GraphicsCards");

            migrationBuilder.DropTable(
                name: "MotherBoards");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CPUVendors");

            migrationBuilder.DropTable(
                name: "Socket");
        }
    }
}
