

namespace PCBuilder.Data.DataSeed
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PCBuilder.Data.Models;

    public class UserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(SeedUser());
        }

        private ApplicationUser[] SeedUser()
        {

            ICollection<ApplicationUser> result = new HashSet<ApplicationUser>();

            ApplicationUser c = new ApplicationUser()
            {
                Id = Guid.Parse("7131367D-D5AD-4F72-B6F7-703BCA071854"),
                UserName = "test@te.ss",
                NormalizedUserName = "test@te.ss",
                Email = "test@te.ss",
                NormalizedEmail = "test@te.ss",
                EmailConfirmed = false,
                PasswordHash = "AQAAAAEAACcQAAAAEIeL1ThpbFZgGCQy+W3bwMXEzGyQJJITuh2tjLMf748mycXZ4ksWgIeBYDSUUais/w==",
                SecurityStamp = "DTUQGIYIXDCNF6ENNSIM7RLNJCLXL4N7",
                ConcurrencyStamp = "881c98c0-da7d-4280-a96b-58a30ae3dda9",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0

            };
            result.Add(c);

            c = new ApplicationUser()
            {
                Id = Guid.Parse("064D17F8-F2BE-4BE9-8F55-C75E58470EDC"),
                UserName = "Administrator@PCBuild.com",
                NormalizedUserName = "Administrator@PCBuild.com",
                Email = "Administrator@PCBuild.com",
                NormalizedEmail = "Administrator@PCBuild.com",
                EmailConfirmed = false,
                PasswordHash = "AQAAAAEAACcQAAAAEB4iohEn/AyAuxhV2+hEs++QvIdV6NMWD0K+kpAZMTiK42jug7QyJurVg4MFOEJxFg==",
                SecurityStamp = "I4C5JH3PX7ZFMSOY5OUZOENYUCQWEM7S",
                ConcurrencyStamp = "aa4f4ee3-5afc-452a-9adb-ed9a042be311",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0

            };
            result.Add(c);


            return result.ToArray();
        }

    }
}
