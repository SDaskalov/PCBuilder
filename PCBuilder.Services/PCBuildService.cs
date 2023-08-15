namespace PCBuilder.Services
{
    using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<PCBuildViewModel>> LastThreeBuildsAsync()
        {
            IEnumerable<PCBuildViewModel> result = await this.dbContext
                .PCConfigurations
                .OrderBy(c => c.CreatedOn)
                .Take(4)
                .Select(s => new PCBuildViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    ImageUrl = s.ComputerCase.ImageUrl,
                    Cpu=s.CPU.ModelName,
                    Gpu=s.GraphicsCard.ModelName ?? "NA",
                    HighestBid=s.HighestBid.ToString(),
                    Motherboard=s.MotherBoard.Name,
                    Ram=s.MotherBoard.RamCapacity.ToString()
                    

                })
           .ToArrayAsync();

            return result;
        }
    }
}
