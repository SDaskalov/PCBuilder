using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PCBuilder.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCBuilder.Data.DataSeed
{
    public class VendorEntityConfiguration : IEntityTypeConfiguration<CpuVendor>
    {
        public void Configure(EntityTypeBuilder<CpuVendor> builder)
        {
            builder.HasData(SeedVendors());
        }

        private CpuVendor[] SeedVendors()
        {

            ICollection<CpuVendor> vendors = new HashSet<CpuVendor>();

            CpuVendor v;

            v = new CpuVendor()
            {
                Id = 1,
                Name = "AMD"
            };
            vendors.Add(v);
            v = new CpuVendor()
            {
                Id = 2,
                Name = "INTEL"
            };
            vendors.Add(v);

            return vendors.ToArray();
        }



    }
}
