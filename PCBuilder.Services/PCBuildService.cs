namespace PCBuilder.Services
{
    using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<PCBuildViewModel>> LastFourBuildsAsync()
        {
            IEnumerable<PCBuildViewModel> result = await this.dbContext
                .PCConfigurations
                .Where(c=>c.IsDeleted == false)
                .OrderBy(c => c.CreatedOn)
                .Take(4)
                .Select(s => new PCBuildViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    ImageUrl = s.ComputerCase.ImageUrl,
                    Cpu=s.CPU.ModelName,
                    Gpu=  s.GraphicsCard==null ? "NA": s.GraphicsCard.ModelName ,
                    HighestBid=s.HighestBid.ToString(),
                    Motherboard=s.MotherBoard.Name,
                    Ram=s.MotherBoard.RamCapacity.ToString()                   

                })
           .ToArrayAsync();

            return result;
        }
    }
}
