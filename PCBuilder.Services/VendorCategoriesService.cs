namespace PCBuilder.Services
{
    using Microsoft.EntityFrameworkCore;
    using PCBuilder.Data;
    using PCBuilder.Services.Contracts;
    using PCBuilder.Web.ViewModels.Vendor;
    public class VendorCategoriesService : IVendorCategoryService
    {
        private readonly PCBuilderDbContext _dbContext;

        public VendorCategoriesService(PCBuilderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CPUVendorCategoryFormModel>> GetAllVendorCategoriesAsync()
        {
            IEnumerable<CPUVendorCategoryFormModel> all = await this._dbContext
                .CPUVendors
                .Select(x => new CPUVendorCategoryFormModel()
                {
                    Name = x.Name,
                    Id = x.Id
                }).ToArrayAsync();

            return all;
        }

        public async Task<bool> VendorExistsById(int id)
        {
            bool result = await  _dbContext.CPUVendors.AnyAsync(x => x.Id == id);
            return result;
        }
    }
}
