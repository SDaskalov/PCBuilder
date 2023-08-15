namespace PCBuilder.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using PCBuilder.Data.DataSeed;
    using PCBuilder.Data.Models;

    public class PCBuilderDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public PCBuilderDbContext(DbContextOptions<PCBuilderDbContext> options)
            : base(options)
        {

        }

        public DbSet<Builder> Builders { get; set; } = null!;

        public DbSet<ComputerCase> ComputerCases { get; set; } = null!;

        public DbSet<CPU> CPUs { get; set; } = null!;

        public DbSet<CpuVendor> CPUVendors { get; set; } = null!;

        public DbSet<GraphicsCard> GraphicsCards { get; set; } = null!;

        public DbSet<MotherBoard> MotherBoards { get; set; } = null!;

        public DbSet<PCConfiguration> PCConfigurations { get; set; } = null!;

        public DbSet<Socket> Sockets { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {

           builder.Entity<Socket>().ToTable(nameof(Socket));

            builder.Entity<PCConfiguration>()
                .HasOne(x=>x.Builder).WithMany()
                .HasForeignKey(x => x.BuilderId)
                .OnDelete(DeleteBehavior.Restrict);                

            builder.Entity<CPU>()
                .HasOne(w => w.Vendor)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<PCConfiguration>()
                .HasOne(x => x.ComputerCase)
                .WithMany()
                .HasForeignKey(x => x.CaseId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<PCConfiguration>()
                .HasOne(x => x.CPU)
                .WithMany()
                .HasForeignKey(x => x.CPUId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<PCConfiguration>()
                .HasOne(x => x.MotherBoard)
                .WithMany()
                .HasForeignKey(x => x.MotherBoardId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.ApplyConfiguration(new VendorEntityConfiguration());
            builder.ApplyConfiguration(new SocketEntityConfiguration());
            builder.ApplyConfiguration(new CPUEntityConfiguration());
            builder.ApplyConfiguration(new GPUEntityConfiguration());
            builder.ApplyConfiguration(new MotherBoardEntityConfiguration());
            builder.ApplyConfiguration(new CaseEntityConfiguration());
            builder.ApplyConfiguration(new PCBuildEntityConfiguration());
            base.OnModelCreating(builder);


        }

    }
}