namespace PCBuilder.Services
{
    using Microsoft.EntityFrameworkCore;
    using PCBuilder.Data;
    using PCBuilder.Services.Contracts;
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
                .AnyAsync(b=>b.UserId.ToString() == userId);

            return result;
        }
    }
}
