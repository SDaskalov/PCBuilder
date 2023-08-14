namespace PCBuilder.Data.DataSeed
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PCBuilder.Data.Models;

    public class GPUEntityConfiguration : IEntityTypeConfiguration<GraphicsCard>
    {
        public void Configure(EntityTypeBuilder<GraphicsCard> builder)
        {
            builder.HasData(SeedGPU());
        }

        internal GraphicsCard[] SeedGPU()
        {
            ICollection<GraphicsCard> result = new HashSet<GraphicsCard>();

            GraphicsCard gp = new GraphicsCard()
            {
                Id = 1,
                MaxWattage = 220,
                ModelName = "GeForce RTX 3070",
                ImageURL = "https://p1.akcdn.net/full/744790884.gigabyte-geforce-rtx-3070-8gb-gddr6-256bit-gv-n3070gaming-oc-8gd.jpg",
                Price = 599.99M

            };

            result.Add(gp);

            gp = new GraphicsCard()
            {
                Id = 2,
                MaxWattage = 400,
                ModelName = "GeForce RTX 4090",
                ImageURL = "https://p1.akcdn.net/full/1122500418.asus-geforce-rtx-4090-oc-24gb-gddr6x-rog-strix-rtx4090-o24g-gaming.jpg",
                Price = 1599.00M
            };
            result.Add(gp);
            gp = new GraphicsCard()
            {
                Id = 3,
                MaxWattage = 355,
                ModelName = "AMD RX 7900XTX",
                ImageURL = "https://pg.asrock.com/Graphics-Card/photo/Radeon%20RX%207900%20XTX%20Phantom%20Gaming%2024GB%20OC(L1).png",
                Price = 999.99M
            };
            result.Add(gp);

            gp = new GraphicsCard()
            {
                Id = 4,
                ImageURL = "https://cdna.pcpartpicker.com/static/forever/images/product/5199e776d5e1c9d319b4a275139bbcf4.1600.jpg",
                MaxWattage = 335,
                ModelName = "AMD RX 6950XT",
                Price = 649.99M

            };
            result.Add(gp);
            return result.ToArray();
        }
    }
}
