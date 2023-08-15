
namespace PCBuilder.Services
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.IdentityModel.Tokens;
    using PCBuilder.Data;
    using PCBuilder.Services.Contracts;
    using PCBuilder.Web.ViewModels.Sockets;
    public class SocketCategoryService : ISocketCategoryService
    {
        private readonly PCBuilderDbContext _dbContext;

        public SocketCategoryService(PCBuilderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<SocketCategoryFormModel>> GetAllSocketCategoriesAsync()
        {

            IEnumerable<SocketCategoryFormModel> sockets = await _dbContext
                .Sockets
                .AsNoTracking()
                .Select(x => new SocketCategoryFormModel()
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToArrayAsync();

            return sockets;

        }
    }
}
