
namespace PCBuilder.Services
{
    using Microsoft.EntityFrameworkCore;
    using PCBuilder.Data;
    using PCBuilder.Data.Models;
    using PCBuilder.Services.Contracts;
    using PCBuilder.Web.ViewModels.ComputerCase;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ComputerCaseService : IComputerCaseService
    {
        private readonly PCBuilderDbContext dbContext;

        public ComputerCaseService(PCBuilderDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(ComputerCaseFormViewModel model, string id)
        {
            ComputerCase cs = new ComputerCase()
            {
                BuilderId = Guid.Parse(id),
                ImageUrl = model.ImageUrl,
                Name = model.ModelName,
                Price = model.Price
            };

            await dbContext.ComputerCases.AddAsync(cs);
            await dbContext.SaveChangesAsync();

        }

        public async Task<IEnumerable<ComputerCaseFormViewModel>> GetAllAsync()
        {
            IEnumerable<ComputerCaseFormViewModel> result = await dbContext
                 .ComputerCases
                 .Where(c => c.IsDeleted == false)
                 .Select(c => new ComputerCaseFormViewModel()
                 {
                     BuilderId = c.BuilderId,
                     Id = c.Id,
                     ImageUrl = c.ImageUrl,
                     ModelName = c.Name,
                     Price = c.Price,
                 }).ToArrayAsync();


            return result;
        }

        public async Task<ComputerCaseFormViewModel?> GetCaseDetailsAsync(int id)
        {
            ComputerCaseFormViewModel? model = await dbContext
                .ComputerCases
                .Where(c => c.Id == id)
                .Select(c => new ComputerCaseFormViewModel()
                {
                    BuilderId = c.BuilderId,
                    Id = c.Id,
                    ImageUrl = c.ImageUrl,
                    ModelName = c.Name,
                    Price = c.Price
                }).FirstOrDefaultAsync();

            return model;

        }

        public async Task<bool> CaseExistsByModelName(string model)
        {
            bool res = await dbContext.ComputerCases.AnyAsync(g => g.Name == model);

            return res;
        }

        public async Task<ComputerCaseFormViewModel?> GetCaseByIdAsync(int id)
        {
            ComputerCaseFormViewModel? cas = await this.dbContext
                .ComputerCases
                .Where(c => c.Id == id)
                .Select(c => new ComputerCaseFormViewModel()
                {
                    BuilderId = c.BuilderId,
                    Id = c.Id,
                    ImageUrl = c.ImageUrl,
                    ModelName = c.Name,
                    Price = c.Price
                    
                }).FirstOrDefaultAsync();

            return cas;
        }
    }
}
