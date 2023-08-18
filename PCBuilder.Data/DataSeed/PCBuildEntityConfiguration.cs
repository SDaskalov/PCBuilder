namespace PCBuilder.Data.DataSeed
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PCBuilder.Data.Models;
    public class PCBuildEntityConfiguration : IEntityTypeConfiguration<PCConfiguration>
    {
        public void Configure(EntityTypeBuilder<PCConfiguration> builder)
        {
            builder.HasData(SeedPCConfig());
        }

        private PCConfiguration[] SeedPCConfig()
        {
            ICollection<PCConfiguration> pcConfigurations = new HashSet<PCConfiguration>();

            PCConfiguration pcConfiguration;

            pcConfiguration = new PCConfiguration()
            {
                Id=1,
                CaseId=1,
                CPUId=1,
                GraphicsCardId=1,
                BuilderId=Guid.Parse("7131367D-D5AD-4F72-B6F7-703BCA071854"),
                MotherBoardId=3,
                TotalSystemWattage=650,
                HighestBid=1200,
                Name="Gaming PC 1",
                CreatedOn=DateTime.Now
            };

            pcConfigurations.Add(pcConfiguration);


            return pcConfigurations.ToArray();
              

        }


    }
}
