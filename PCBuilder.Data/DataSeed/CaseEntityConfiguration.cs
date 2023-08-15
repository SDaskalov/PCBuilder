namespace PCBuilder.Data.DataSeed
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PCBuilder.Data.Models;

    public class CaseEntityConfiguration : IEntityTypeConfiguration<ComputerCase>
    {
        public void Configure(EntityTypeBuilder<ComputerCase> builder)
        {
            builder.HasData(SeedCases());
        }

        private ComputerCase[] SeedCases()
        {

            ICollection<ComputerCase> cases = new HashSet<ComputerCase>();

            ComputerCase cs = new ComputerCase()
            {
                Id = 1,
                Name = "Fractal Design North",
                Price=180.00M,
                ImageUrl= "https://www.altech.bg/files/products/118756.jpg"
            };
            cases.Add(cs);
            cs = new ComputerCase()
            {
                Id= 2,
                Name= "Lian Li Lancool 216",
                Price=119.99M,
                ImageUrl= "https://images10.newegg.com/BizIntell/item/Case/Cases%20(Computer%20Cases%20-%20ATX%20Form)/2AM-000Z-000A9/1.jpg"

            };
            cases.Add(cs);
            cs = new ComputerCase()
            {
                Id=3,
                Name= "Fractal Design Torrent",
                Price=199.99M,
                ImageUrl= "https://www.pro-bg.com/resize_image_max/800/600/FRACTAL%20DESIGN/Computer-Case-FractalDesign-TORRENT-BLACK-SOLID.jpeg"
            };
            cases.Add(cs);

            return cases.ToArray();

        }
    }
}


