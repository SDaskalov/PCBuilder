namespace PCBuilder.Data.DataSeed
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PCBuilder.Data.Models;

    public class MotherBoardEntityConfiguration : IEntityTypeConfiguration<MotherBoard>
    {
        public void Configure(EntityTypeBuilder<MotherBoard> builder)
        {
            builder.HasData(SeedMB());
        }
        internal MotherBoard[] SeedMB()
        {

            ICollection<MotherBoard> result = new HashSet<MotherBoard>();


            MotherBoard mb = new MotherBoard()
            {
                Id = 1,
                Name = "MSI PRO B650M-A WIFI",
                Price = 199.99M,
                RamCapacity = 128,
                SocketId = 2,
                VendorId = 1,
                ImageUrl= "https://ardes.bg/uploads/original/msi-pro-b650m-a-wifi-am5-423853.jpg"
            };

            result.Add(mb);

            mb = new MotherBoard()
            {
                Id = 2,
                Name = "ASUS TUF GAMING B650-PLUS",
                Price = 228.99M,
                RamCapacity = 128,
                SocketId = 2,
                VendorId = 1,
                ImageUrl= "https://ardes.bg/uploads/original/asus-tuf-gaming-b650-plus-417061.jpg"
            };
            result.Add(mb);

            mb = new MotherBoard()
            {
                Id = 3,
                Name = "GIGABYTE B550 AORUS ELITE V2",
                Price = 189.99M,
                RamCapacity = 128,
                SocketId = 1,
                VendorId = 1,
                ImageUrl= "https://p1.akcdn.net/full/748039353.gigabyte-b550-aorus-elite-v2.jpg"

            };

            result.Add(mb);
            mb = new MotherBoard()
            {
                Id = 4,
                Name = "MSI MAG B550 Tomahawk",
                Price = 150.00M,
                RamCapacity = 256,
                SocketId = 1,
                VendorId = 1,
                ImageUrl= "https://storage-asset.msi.com/global/picture/image/feature/mb/B550/MAG/TOMAHAWK-MAX-WIFI/msi-mag-b550-tomahawk-max-wifi-hero-board01.png"
            };
            result.Add(mb);
            mb = new MotherBoard()
            {
                Id = 5,
                Name = "Gigabyte Motherboard Z790 AORUS ELITE AX",
                Price = 299.99M,
                RamCapacity = 256,
                SocketId = 4,
                VendorId = 2,
                ImageUrl= "https://www.vario.bg/images/product/37965/GIGABYTE%20Z790%20AORUS%20Elite%20AX.jpg"
            };
            result.Add(mb);
            mb = new MotherBoard()
            {
                Id = 6,
                Name = "ASUS TUF GAMING Z790-PLUS WIFI D4 ",
                Price = 249.99M,
                RamCapacity = 256,
                SocketId = 4,
                VendorId = 2,
                ImageUrl= "https://pcbuild.bg/assets/products/000/000/267/000000267208--danna-platka-asus-tuf-gaming-z790-plus-d4-lga1700-ddr4.jpg"
            };
            result.Add(mb);
           
            return result.ToArray();
         

        }


    }
}
