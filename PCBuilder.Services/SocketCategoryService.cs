
namespace PCBuilder.Services
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.IdentityModel.Tokens;
    using PCBuilder.Data;
    using PCBuilder.Services.Contracts;
    using PCBuilder.Web.ViewModels.Sockets;
    public class SocketCategoryService : ISocketCategoryService
    {
        private readonly PCBuilderDbContext dbContext;

        public SocketCategoryService(PCBuilderDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<SocketCategoryFormModel>> GetAllSocketCategoriesAsync()
        {

            IEnumerable<SocketCategoryFormModel> sockets = await 
                this.dbContext
                .Sockets
                .Select(x => new SocketCategoryFormModel()
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToArrayAsync();

            return sockets;

        }

        public async Task<bool> SocketExistsById(int id)
        {

            bool res = await dbContext.Sockets.AnyAsync(x => x.Id == id);
            return res;
        }




    }
}
