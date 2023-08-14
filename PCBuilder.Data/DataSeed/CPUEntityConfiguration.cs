namespace PCBuilder.Data.DataSeed
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PCBuilder.Data.Models;

    public class CPUEntityConfiguration : IEntityTypeConfiguration<CPU>
    {
        public void Configure(EntityTypeBuilder<CPU> builder)
        {
            builder.HasData(SeedCPUS());
        }

        private CPU[] SeedCPUS()
        {

            ICollection<CPU> result = new HashSet<CPU>();

            CPU c = new CPU()
            {
                Id = 1,
                ModelName = "Ryzen 9 5900x",
                IntegratedGraphics = false,
                MaxWattage = 95,
                Price = 450.00M,
                SocketId = 1,
                VendorId = 1
            };


            result.Add(c);
            c = new CPU()
            {
                Id = 2,
                ModelName = "Ryzen 7 7700x",
                IntegratedGraphics = true,
                MaxWattage = 105,
                Price = 550.00M,
                SocketId = 2,
                VendorId = 1
            };
            result.Add(c);
            c = new CPU()
            {
                Id = 3,
                ModelName = "Intel Core i7-13700",
                IntegratedGraphics = true,
                MaxWattage = 105,
                Price = 550.00M,
                SocketId = 4,
                VendorId = 2
            };
            result.Add(c);
            c = new CPU()
            {
                Id = 4,
                ModelName = "Intel Core i9-11900KF",
                IntegratedGraphics = false,
                MaxWattage = 125,
                Price = 990.00M,
                SocketId = 3,
                VendorId = 2
            };
            result.Add(c);


            return result.ToArray();
        }

    }
}
