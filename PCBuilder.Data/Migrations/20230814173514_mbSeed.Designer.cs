﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PCBuilder.Data;

#nullable disable

namespace PCBuilder.Data.Migrations
{
    [DbContext(typeof(PCBuilderDbContext))]
    [Migration("20230814173514_mbSeed")]
    partial class mbSeed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("PCBuilder.Data.Models.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("PCBuilder.Data.Models.Builder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PublicBuilderName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Builders");
                });

            modelBuilder.Entity("PCBuilder.Data.Models.ComputerCase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("ComputerCases");
                });

            modelBuilder.Entity("PCBuilder.Data.Models.CPU", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IntegratedGraphics")
                        .HasColumnType("bit");

                    b.Property<int>("MaxWattage")
                        .HasColumnType("int");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SocketId")
                        .HasColumnType("int");

                    b.Property<int>("VendorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SocketId");

                    b.HasIndex("VendorId");

                    b.ToTable("CPUs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IntegratedGraphics = false,
                            MaxWattage = 95,
                            ModelName = "Ryzen 9 5900x",
                            Price = 450.00m,
                            SocketId = 1,
                            VendorId = 1
                        },
                        new
                        {
                            Id = 2,
                            IntegratedGraphics = true,
                            MaxWattage = 105,
                            ModelName = "Ryzen 7 7700x",
                            Price = 550.00m,
                            SocketId = 2,
                            VendorId = 1
                        },
                        new
                        {
                            Id = 3,
                            IntegratedGraphics = true,
                            MaxWattage = 105,
                            ModelName = "Intel Core i7-13700",
                            Price = 550.00m,
                            SocketId = 4,
                            VendorId = 2
                        },
                        new
                        {
                            Id = 4,
                            IntegratedGraphics = false,
                            MaxWattage = 125,
                            ModelName = "Intel Core i9-11900KF",
                            Price = 990.00m,
                            SocketId = 3,
                            VendorId = 2
                        });
                });

            modelBuilder.Entity("PCBuilder.Data.Models.CpuVendor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("CpuVendor");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "AMD"
                        },
                        new
                        {
                            Id = 2,
                            Name = "INTEL"
                        });
                });

            modelBuilder.Entity("PCBuilder.Data.Models.GraphicsCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<int>("MaxWattage")
                        .HasColumnType("int");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("GraphicsCards");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageURL = "https://p1.akcdn.net/full/744790884.gigabyte-geforce-rtx-3070-8gb-gddr6-256bit-gv-n3070gaming-oc-8gd.jpg",
                            MaxWattage = 220,
                            ModelName = "GeForce RTX 3070",
                            Price = 599.99m
                        },
                        new
                        {
                            Id = 2,
                            ImageURL = "https://p1.akcdn.net/full/1122500418.asus-geforce-rtx-4090-oc-24gb-gddr6x-rog-strix-rtx4090-o24g-gaming.jpg",
                            MaxWattage = 400,
                            ModelName = "GeForce RTX 4090",
                            Price = 1599.00m
                        },
                        new
                        {
                            Id = 3,
                            ImageURL = "https://pg.asrock.com/Graphics-Card/photo/Radeon%20RX%207900%20XTX%20Phantom%20Gaming%2024GB%20OC(L1).png",
                            MaxWattage = 355,
                            ModelName = "AMD RX 7900XTX",
                            Price = 999.99m
                        },
                        new
                        {
                            Id = 4,
                            ImageURL = "https://cdna.pcpartpicker.com/static/forever/images/product/5199e776d5e1c9d319b4a275139bbcf4.1600.jpg",
                            MaxWattage = 335,
                            ModelName = "AMD RX 6950XT",
                            Price = 649.99m
                        });
                });

            modelBuilder.Entity("PCBuilder.Data.Models.MotherBoard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RamCapacity")
                        .HasColumnType("int");

                    b.Property<int>("SocketId")
                        .HasColumnType("int");

                    b.Property<int>("VendorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SocketId");

                    b.HasIndex("VendorId");

                    b.ToTable("MotherBoards");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "MSI PRO B650M-A WIFI",
                            Price = 199.99m,
                            RamCapacity = 128,
                            SocketId = 2,
                            VendorId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "ASUS TUF GAMING B650-PLUS",
                            Price = 228.99m,
                            RamCapacity = 128,
                            SocketId = 2,
                            VendorId = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "GIGABYTE B550 AORUS ELITE V2",
                            Price = 189.99m,
                            RamCapacity = 128,
                            SocketId = 1,
                            VendorId = 1
                        },
                        new
                        {
                            Id = 4,
                            Name = "MSI MAG B550 Tomahawk",
                            Price = 150.00m,
                            RamCapacity = 256,
                            SocketId = 1,
                            VendorId = 1
                        },
                        new
                        {
                            Id = 5,
                            Name = "Gigabyte Motherboard Z790 AORUS ELITE AX",
                            Price = 299.99m,
                            RamCapacity = 256,
                            SocketId = 4,
                            VendorId = 2
                        },
                        new
                        {
                            Id = 6,
                            Name = "ASUS TUF GAMING Z790-PLUS WIFI D4 ",
                            Price = 249.99m,
                            RamCapacity = 256,
                            SocketId = 4,
                            VendorId = 2
                        },
                        new
                        {
                            Id = 7,
                            Name = "MSI MPG Z490 Gaming Plus",
                            Price = 189.99m,
                            RamCapacity = 128,
                            SocketId = 3,
                            VendorId = 2
                        });
                });

            modelBuilder.Entity("PCBuilder.Data.Models.PCConfiguration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<Guid?>("BidderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BuilderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BuilderId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CPUId")
                        .HasColumnType("int");

                    b.Property<int>("CaseId")
                        .HasColumnType("int");

                    b.Property<int?>("GraphicsCardId")
                        .HasColumnType("int");

                    b.Property<decimal>("HighestBid")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("MotherBoardId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalSystemWattage")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BidderId");

                    b.HasIndex("BuilderId");

                    b.HasIndex("BuilderId1");

                    b.HasIndex("CPUId");

                    b.HasIndex("CaseId");

                    b.HasIndex("GraphicsCardId");

                    b.HasIndex("MotherBoardId");

                    b.ToTable("PCConfigurations");
                });

            modelBuilder.Entity("PCBuilder.Data.Models.Socket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Socket");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "AM4"
                        },
                        new
                        {
                            Id = 2,
                            Name = "AM5"
                        },
                        new
                        {
                            Id = 3,
                            Name = "LGA1200"
                        },
                        new
                        {
                            Id = 4,
                            Name = "LGA1700"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("PCBuilder.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("PCBuilder.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PCBuilder.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("PCBuilder.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PCBuilder.Data.Models.Builder", b =>
                {
                    b.HasOne("PCBuilder.Data.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PCBuilder.Data.Models.CPU", b =>
                {
                    b.HasOne("PCBuilder.Data.Models.Socket", "Socket")
                        .WithMany()
                        .HasForeignKey("SocketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PCBuilder.Data.Models.CpuVendor", "Vendor")
                        .WithMany()
                        .HasForeignKey("VendorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Socket");

                    b.Navigation("Vendor");
                });

            modelBuilder.Entity("PCBuilder.Data.Models.MotherBoard", b =>
                {
                    b.HasOne("PCBuilder.Data.Models.Socket", "Socket")
                        .WithMany()
                        .HasForeignKey("SocketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PCBuilder.Data.Models.CpuVendor", "Vendor")
                        .WithMany()
                        .HasForeignKey("VendorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Socket");

                    b.Navigation("Vendor");
                });

            modelBuilder.Entity("PCBuilder.Data.Models.PCConfiguration", b =>
                {
                    b.HasOne("PCBuilder.Data.Models.ApplicationUser", "Bidder")
                        .WithMany("Configurations")
                        .HasForeignKey("BidderId");

                    b.HasOne("PCBuilder.Data.Models.Builder", null)
                        .WithMany("Builds")
                        .HasForeignKey("BuilderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PCBuilder.Data.Models.Builder", "Builder")
                        .WithMany()
                        .HasForeignKey("BuilderId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PCBuilder.Data.Models.CPU", "CPU")
                        .WithMany()
                        .HasForeignKey("CPUId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PCBuilder.Data.Models.ComputerCase", "ComputerCase")
                        .WithMany()
                        .HasForeignKey("CaseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PCBuilder.Data.Models.GraphicsCard", "GraphicsCard")
                        .WithMany()
                        .HasForeignKey("GraphicsCardId");

                    b.HasOne("PCBuilder.Data.Models.MotherBoard", "MotherBoard")
                        .WithMany()
                        .HasForeignKey("MotherBoardId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Bidder");

                    b.Navigation("Builder");

                    b.Navigation("CPU");

                    b.Navigation("ComputerCase");

                    b.Navigation("GraphicsCard");

                    b.Navigation("MotherBoard");
                });

            modelBuilder.Entity("PCBuilder.Data.Models.ApplicationUser", b =>
                {
                    b.Navigation("Configurations");
                });

            modelBuilder.Entity("PCBuilder.Data.Models.Builder", b =>
                {
                    b.Navigation("Builds");
                });
#pragma warning restore 612, 618
        }
    }
}
