namespace PCBuilder.Data.DataSeed
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PCBuilder.Data.Models;

    public class BuilderEntityConfiguration : IEntityTypeConfiguration<Builder>
    {
        public void Configure(EntityTypeBuilder<Builder> builder)
        {
            builder.HasData(SeedUser());
        }

        private Builder[] SeedUser()
        {

            ICollection<Builder> result = new HashSet<Builder>();

            Builder c = new Builder()
            {
                Id = Guid.Parse("7131367D-D5AD-4F72-B6F7-703BCA071854"),
                PublicBuilderName="SEEEDBUILDER NAME",
                UserId= Guid.Parse("7131367D-D5AD-4F72-B6F7-703BCA071854")

            };
            result.Add(c);
                       


            return result.ToArray();
        }

    }
}
