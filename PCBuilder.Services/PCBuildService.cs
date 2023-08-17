namespace PCBuilder.Services
{
    using Microsoft.EntityFrameworkCore;

    using PCBuilder.Data;
    using PCBuilder.Data.Models;
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

        public async Task BidForPcAsync(int id, string bidder)
        {
            PCConfiguration? pc = await this.dbContext
                .PCConfigurations
                .Where(c => c.Id == id && c.IsDeleted == false && c.IsSold == false)
                .FirstOrDefaultAsync();

            if (pc != null)
            {
                pc.BidderId = Guid.Parse(bidder);
                pc.HighestBid = pc.HighestBid + 100;
            }

            await this.dbContext.SaveChangesAsync();


        }

        public async Task CheckSaleDateForPCAsync()
        {


            var activeBuilds = await this.dbContext.PCConfigurations.Where(x => x.IsDeleted == false).ToListAsync();


            foreach (var build in activeBuilds)
            {
                if (build.CreatedOn.AddDays(10) > DateTime.Now)
                {
                    build.IsDeleted = true;
                }
            }
            this.dbContext.PCConfigurations.UpdateRange(activeBuilds);
            await this.dbContext.SaveChangesAsync();

        }

        public async Task CreateAsync(PCBuildCreateFormViewModel model, string id, string userId)
        {

            PCConfiguration pc = new PCConfiguration()
            {
                CreatedOn = DateTime.Now,
                BidderId = Guid.Parse(userId),
                BuilderId = Guid.Parse(id),
                CaseId = model.ComputerCaseId,
                CPUId = model.CPUId,
                GraphicsCardId = model.GPUId,
                HighestBid = model.InitialRequestedBid,
                MotherBoardId = model.MotherboardId,
                Name = model.Name,

            };


            pc.TotalSystemWattage = model.CPUPower + model.GpuPower;


            await this.dbContext.PCConfigurations.AddAsync(pc);
            await this.dbContext.SaveChangesAsync();




        }

        public async Task<PCBuildDetailsViewModel?> GetPCDetailsAsync(int id)
        {
            PCBuildDetailsViewModel? pc = await dbContext
                .PCConfigurations
                .Where(x => x.Id == id && x.IsDeleted == false )
                .Select(x => new PCBuildDetailsViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    CpuId = x.CPUId,
                    HighestBid = x.HighestBid.ToString(),
                    GpuId = x.GraphicsCardId ?? 0,
                    ImageUrl = x.ComputerCase.ImageUrl,
                    MotherboardId = x.MotherBoardId,
                    Ram = x.MotherBoard.RamCapacity.ToString(),
                    CaseId = x.CaseId,
                    CreatedOn = x.CreatedOn,
                    HighestBidderId = x.BidderId ?? new Guid(),
                    CreatorId = x.BuilderId,
                    isSold = x.IsSold,

                }).FirstOrDefaultAsync();

            return pc;
        }

        public async Task<bool> CheckifPCExistsByIdAsync(int id)
        {
            bool res = await dbContext
                  .PCConfigurations
                  .Where(x => x.Id == id && x.IsDeleted == false )
                  .AnyAsync();

            return res;
        }



        public async Task<IEnumerable<PCBuildViewModel>> LastFourBuildsAsync()
        {
            IEnumerable<PCBuildViewModel> result = await this.dbContext
                .PCConfigurations
                .Where(c => c.IsDeleted == false && c.IsSold == false)
                .OrderByDescending(c => c.CreatedOn)
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
                    Ram = s.MotherBoard.RamCapacity.ToString(),
                    

                })
           .ToArrayAsync();
            return result;
        }
        public async Task<IEnumerable<PCBuildDetailsViewModel>> AllBuildsAsync()
        {
            IEnumerable<PCBuildDetailsViewModel> result = await this.dbContext
                .PCConfigurations
                .Where(c => c.IsDeleted == false && c.IsSold == false)
                .OrderByDescending(c => c.CreatedOn)
                .Select(s => new PCBuildDetailsViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    ImageUrl = s.ComputerCase.ImageUrl,
                    CreatedOn = s.CreatedOn,
                    MotherboardId = s.MotherBoard.Id,
                    CaseId = s.CaseId,
                    CpuId = s.CPUId,
                    HighestBid = s.HighestBid.ToString(),
                    CreatorId = s.BuilderId,
                    Ram = s.MotherBoard.RamCapacity.ToString(),
                    isSold = s.IsSold,
                    
                })
           .ToArrayAsync();

            return result;
        }

        public async Task SellPcAsync(int id, string bidderid)
        {
            PCConfiguration? pc = await this.dbContext
             .PCConfigurations
             .Where(c => c.Id == id && c.IsDeleted == false)
             .FirstOrDefaultAsync();

            if (pc != null)
            {               
                pc.IsSold = true;
            }

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<PCBuildDetailsViewModel>> AllOwnedBuildsAsync(string id)
        {
            IEnumerable<PCBuildDetailsViewModel> result = await this.dbContext
                .PCConfigurations
                .Where(c => c.IsDeleted == false && c.IsSold == true && c.BidderId == Guid.Parse(id) )
                .OrderBy(c => c.CreatedOn)
                .Select(s => new PCBuildDetailsViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    ImageUrl = s.ComputerCase.ImageUrl,
                    CreatedOn = s.CreatedOn,
                    MotherboardId = s.MotherBoard.Id,
                    CaseId = s.CaseId,
                    CpuId = s.CPUId,
                    HighestBid = s.HighestBid.ToString(),
                    CreatorId = s.BuilderId,
                    Ram = s.MotherBoard.RamCapacity.ToString(),
                    isSold = s.IsSold,

                })
           .ToArrayAsync();

            return result;
        }
    }
}
