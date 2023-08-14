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
                VendorId = 1
            };

            result.Add(mb);

            mb = new MotherBoard()
            {
                Id = 2,
                Name = "ASUS TUF GAMING B650-PLUS",
                Price = 228.99M,
                RamCapacity = 128,
                SocketId = 2,
                VendorId = 1
            };
            result.Add(mb);

            mb = new MotherBoard()
            {
                Id = 3,
                Name = "GIGABYTE B550 AORUS ELITE V2",
                Price = 189.99M,
                RamCapacity = 128,
                SocketId = 1,
                VendorId = 1

            };

            result.Add(mb);
            mb = new MotherBoard()
            {
                Id = 4,
                Name = "MSI MAG B550 Tomahawk",
                Price = 150.00M,
                RamCapacity = 256,
                SocketId = 1,
                VendorId = 1
            };
            result.Add(mb);
            mb = new MotherBoard()
            {
                Id = 5,
                Name = "Gigabyte Motherboard Z790 AORUS ELITE AX",
                Price = 299.99M,
                RamCapacity = 256,
                SocketId = 4,
                VendorId = 2
            };
            result.Add(mb);
            mb = new MotherBoard()
            {
                Id = 6,
                Name = "ASUS TUF GAMING Z790-PLUS WIFI D4 ",
                Price = 249.99M,
                RamCapacity = 256,
                SocketId = 4,
                VendorId = 2
            };
            result.Add(mb);
            mb = new MotherBoard()
            {
                Id = 7,
                Name= "MSI MPG Z490 Gaming Plus",
                Price=189.99M,
                RamCapacity = 128,
                SocketId = 3,
                VendorId = 2
            };
            result.Add(mb);
            return result.ToArray();
         

        }


    }
}
