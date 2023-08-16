namespace PCBuilder.Services
{
    using Microsoft.EntityFrameworkCore;

    using PCBuilder.Data;
    using PCBuilder.Services.Contracts;
    using PCBuilder.Web.ViewModels.PCConfiguration;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class PCBuildService : IPCBuildService
    {
        private readonly PCBuilderDbContext dbContext;


        public PCBuildService(PCBuilderDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<PCBuildDetailsViewModel?> GetPCDetailsAsync(int id)
        {
            PCBuildDetailsViewModel? pc = await dbContext
                .PCConfigurations
                .Where(x => x.Id == id)
                .Select(x => new PCBuildDetailsViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    CpuId = x.CPUId,
                    HighestBid = x.HighestBid.ToString(),
                    GpuId = x.GraphicsCardId?? 0,
                    ImageUrl = x.ComputerCase.ImageUrl,
                    MotherboardId = x.MotherBoardId,
                    Ram = x.MotherBoard.RamCapacity.ToString(),
                    CaseId = x.CaseId

                }).FirstOrDefaultAsync();

            return pc;
        }

        public async Task<IEnumerable<PCBuildViewModel>> LastFourBuildsAsync()
        {
            IEnumerable<PCBuildViewModel> result = await this.dbContext
                .PCConfigurations
                .Where(c => c.IsDeleted == false)
                .OrderBy(c => c.CreatedOn)
                .Take(4)
                .Select(s => new PCBuildViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    ImageUrl = s.ComputerCase.ImageUrl,
                    Cpu = s.CPU.ModelName,
                    Gpu = s.GraphicsCard == null ? "NA" : s.GraphicsCard.ModelName,
                    HighestBid = s.HighestBid.ToString(),
                    Motherboard = s.MotherBoard.Name,
                    Ram = s.MotherBoard.RamCapacity.ToString()

                })
           .ToArrayAsync();

            return result;
        }
    }
}
