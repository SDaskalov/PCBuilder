namespace PCBuilder.Services
{
    using Microsoft.EntityFrameworkCore;
    using PCBuilder.Data;
    using PCBuilder.Data.Models;
    using PCBuilder.Services.Contracts;
    using PCBuilder.Web.ViewModels.CPU;
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


        public async Task CreateAsync(CPUFormViewModel model)
        {
            CPU cPU = new CPU()
            {
                Price = model.Price,
                SocketId = model.SocketId,
                MaxWattage = model.MaxWattage,
                IntegratedGraphics=model.IntegratedGraphics,
                ModelName = model.ModelName,
                VendorId = model.VendorId
            };


          await   this._dbContext.CPUs.AddAsync(cPU);
            await this._dbContext.SaveChangesAsync();

        }
    }
}
