﻿namespace PCBuilder.Services
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

        public async Task BidForPcAsync(int id,string bidder)
        {
            PCConfiguration? pc = await this.dbContext
                .PCConfigurations
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
             
            if (pc != null)
            {
                pc.BidderId=Guid.Parse(bidder);
                pc.HighestBid = pc.HighestBid + 100;
            }

            await this.dbContext.SaveChangesAsync();

                
        }

        public async Task CheckSaleDateForPCAsync()
        {


           var activeBuilds= await this.dbContext.PCConfigurations.Where(x=>x.IsDeleted==false).ToListAsync();

            
            foreach (var build in activeBuilds)
            {
                if (build.CreatedOn.AddDays(10) > DateTime.Now)
                {
                    build.IsDeleted=true;
                }
            }
             this.dbContext.PCConfigurations.UpdateRange(activeBuilds);
            await this.dbContext.SaveChangesAsync();

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
                    CaseId = x.CaseId,
                    CreatedOn = x.CreatedOn,
                    HighestBidderId=x.BidderId?? new Guid()

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
