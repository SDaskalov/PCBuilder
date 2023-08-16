
namespace PCBuilder.Services
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;
    using PCBuilder.Data;
    using PCBuilder.Data.Models;
    using PCBuilder.Services.Contracts;
    using PCBuilder.Web.ViewModels.GPU;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class GPUService : IGPUService
    {

        private readonly PCBuilderDbContext dbContext;

        public GPUService(PCBuilderDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<GPUFormViewModel?> GetGPUByIdAsync(int id)
        {
            GPUFormViewModel? view = await dbContext
                .GraphicsCards
                .Where (x => x.Id == id)
                .Select (x => new GPUFormViewModel
                {
                    Id = x.Id,
                    BuilderId = x.BuilderId,
                    ImageUrl=x.ImageURL,
                    MaxWattage = x.MaxWattage,
                    ModelName = x.ModelName,
                    Price = x.Price,
                }).FirstOrDefaultAsync();
            return view;

        }

        public async Task<bool> GPUExistsByModelName(string model)
        {
            bool res = await dbContext.GraphicsCards.AnyAsync(g=>g.ModelName == model);

            return res;
        }

        public async Task CreateAsync(GPUFormViewModel model, string id)
        {
            GraphicsCard card = new GraphicsCard()
            {
                BuilderId = Guid.Parse(id),
                ImageURL = model.ImageUrl,
                MaxWattage = model.MaxWattage,
                ModelName = model.ModelName,
                Price = model.Price
            };

            await dbContext.GraphicsCards.AddAsync(card);
            await dbContext.SaveChangesAsync();

        }

        public async Task<IEnumerable<GPUFormViewModel>> GetAllAsync()
        {
            IEnumerable<GPUFormViewModel> gpus = await dbContext
                .GraphicsCards
                .Where(x => x.IsDeleted == false)
                .Select(x => new GPUFormViewModel()
                {
                    Id = x.Id,
                    BuilderId = x.BuilderId,
                    ImageUrl = x.ImageURL,
                    MaxWattage = x.MaxWattage,
                    ModelName = x.ModelName,
                    Price = x.Price
                }).ToArrayAsync();
            return gpus;
        }

        public async Task<GPUFormViewModel?> GetGPUDetailsAsync(int id)
        {
            GPUFormViewModel? gpu = await dbContext
                .GraphicsCards
                .Where(x => x.Id == id)
                .Select(x => new GPUFormViewModel()
                {
                    Id = x.Id,
                    BuilderId = x.BuilderId,
                    ImageUrl = x.ImageURL,
                    MaxWattage = x.MaxWattage,
                    ModelName = x.ModelName,
                    Price = x.Price
                }).FirstOrDefaultAsync();

            return gpu;

        }
    }
}
