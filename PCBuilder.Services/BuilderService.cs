namespace PCBuilder.Services
{
    using Microsoft.EntityFrameworkCore;
    using PCBuilder.Data;
    using PCBuilder.Data.Models;
    using PCBuilder.Services.Contracts;
    using PCBuilder.Web.ViewModels.Builder;

    public class BuilderService : IBuilderService
    {
        private readonly PCBuilderDbContext dbContext;

        public BuilderService(PCBuilderDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> BuilderAlreadyExcistsByUserId(string userId)
        {
            bool result = await this.dbContext
                .Builders
                .AnyAsync(b => b.UserId.ToString() == userId);

            return result;
        }

        public async Task<bool> BuilderNameIsTaken(string name)
        {
            bool result = await this.dbContext
               .Builders
               .AnyAsync(b => b.PublicBuilderName == name);

            return result;
        }

        public async Task Create(string userId, BecomeBuilderFormModel model)
        {
            Builder bd = new Builder()
            {
                UserId = Guid.Parse(userId),
                PublicBuilderName = model.PublicBuilderName
            };
            await this.dbContext.Builders.AddAsync(bd);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<bool> HasPCWithIdAsync(string? userId, string buildId)
        {
            Builder? builder = await this.dbContext.Builders.Include(p => p.Builds).FirstOrDefaultAsync(a => a.UserId.ToString() == userId);

            if (builder == null)
            {
                return false;
            }
            return builder.Builds.Any(b=>b.Id.ToString()==buildId);

        }
    }
}
