namespace PCBuilder.Services
{
    using Microsoft.EntityFrameworkCore;
    using PCBuilder.Data;
    using PCBuilder.Data.Models;
    using PCBuilder.Services.Contracts;
    using PCBuilder.Web.ViewModels.CPU;
    using System.Collections.Generic;


    public class CPUService : ICPUService
    {

        private readonly PCBuilderDbContext _dbContext;

        public CPUService(PCBuilderDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        public async Task<bool> CPUExistsByModelName(string model)
        {

            bool res = await _dbContext.CPUs.AnyAsync(x => x.ModelName == model);
            return res;
        }


        public async Task CreateAsync(CPUFormViewModel model,string id)
        {
            CPU cPU = new CPU()
            {
                Price = model.Price,
                SocketId = model.SocketId,
                MaxWattage = model.MaxWattage,
                IntegratedGraphics=model.IntegratedGraphics,
                ModelName = model.ModelName,
                VendorId = model.VendorId,
                BuilderId=Guid.Parse(id)
                
               
            };


          await   this._dbContext.CPUs.AddAsync(cPU);
            await this._dbContext.SaveChangesAsync();

        }

        public async Task<IEnumerable<CPUFormViewModel>> GetAllAsync()
        {
            IEnumerable<CPUFormViewModel> res = await _dbContext
                .CPUs
                .Where(c => c.IsDeleted == false)
                .Select(c => new CPUFormViewModel()
            {
                Id = c.Id,
                MaxWattage = c.MaxWattage,
                ModelName = c.ModelName,
                VendorId = c.VendorId,
                IntegratedGraphics = c.IntegratedGraphics,
                SocketId = c.SocketId,
                Price = c.Price
            }).ToArrayAsync();
                


                return res;
        }

        public async Task<IEnumerable<CPUDetailsViewModel>> GetAllCPUCategoriesAsync()
        {
            IEnumerable<CPUDetailsViewModel> details = await this._dbContext
                .CPUs
                .Where (c => c.IsDeleted == false)
                .Select (c => new CPUDetailsViewModel()
                {
                    Id = c.Id,
                    IntegratedGraphics = c.IntegratedGraphics,
                    MaxWattage = c.MaxWattage,
                    ModelName = c.ModelName,
                    VendorId = c.VendorId,
                    SocketId = c.SocketId,
                    VendorName = c.Vendor.Name,
                    SocketName = c.Socket.Name,
                    Price = c.Price
                }).ToArrayAsync ();

            return details;
        }

        public async Task<CPUDetailsViewModel?> GetCPUByIdAsync(int id)
        {
            CPUDetailsViewModel? cpu = await this._dbContext
                .CPUs
                .Where (c => c.Id == id)
                .Select (c => new CPUDetailsViewModel() { Id = c.Id,
                IntegratedGraphics= c.IntegratedGraphics,
                MaxWattage= c.MaxWattage,
                ModelName = c.ModelName,
                VendorId = c.VendorId,
                SocketId= c.SocketId,
                VendorName=c.Vendor.Name,
                SocketName=c.Socket.Name,
                Price= c.Price                
                }).FirstOrDefaultAsync();

            return cpu;
        }

        public async Task<CPUDetailsViewModel?> GetCPUDetailsAsync(int id)
        {
            CPUDetailsViewModel? model = await this._dbContext
                .CPUs
                .Where (c => c.Id == id)
                .Select(c => new CPUDetailsViewModel() 
                { 
                    Id = c.Id,
                    IntegratedGraphics =c.IntegratedGraphics,
                    ModelName=c.ModelName,
                    MaxWattage=c.MaxWattage,
                    Price=c.Price,
                    SocketId=c.SocketId,
                    VendorId=c.VendorId,
                    SocketName=c.Socket.Name,
                    VendorName=c.Vendor.Name
                }).FirstOrDefaultAsync();

            return model;
        }
    }
}
