namespace PCBuilder.Services
{
    using Microsoft.IdentityModel.Tokens;
    using PCBuilder.Data;
    using PCBuilder.Services.Contracts;
    using PCBuilder.Web.ViewModels.Home;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class PCBuildService : IPCBuildService
    {
        private readonly PCBuilderDbContext dbContext;

        public PCBuildService(PCBuilderDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<IEnumerable<PCBuildViewModel>> LastThreeBuildsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
