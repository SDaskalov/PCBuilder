namespace PCBuilder.Data.DataSeed
{

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PCBuilder.Data.Models;

    public class VendorEntityConfiguration : IEntityTypeConfiguration<CpuVendor>
    {
        public void Configure(EntityTypeBuilder<CpuVendor> builder)
        {
            builder.HasData(SeedVendors());
        }

        private Socket[] SeedVendors()
        {

            ICollection<Socket> vendors = new HashSet<Socket>();

            Socket v;

            v = new Socket()
            {
                Id = 1,
                Name = "AMD"
            };
            vendors.Add(v);
            v = new Socket()
            {
                Id = 2,
                Name = "INTEL"
            };
            vendors.Add(v);

            return vendors.ToArray();
        }



    }
}
