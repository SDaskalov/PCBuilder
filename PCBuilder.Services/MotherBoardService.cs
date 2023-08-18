
namespace PCBuilder.Services
{
    using Microsoft.EntityFrameworkCore;
    using PCBuilder.Data;
    using PCBuilder.Data.Models;
    using PCBuilder.Services.Contracts;
    using PCBuilder.Web.ViewModels.Motherboard;
    public class MotherBoardService : IMotherBoardService
    {

        private readonly PCBuilderDbContext _dbContext;

        public MotherBoardService(PCBuilderDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<bool> MBExistsByModelName(string model)
        {
            bool res = await _dbContext.MotherBoards.AnyAsync(x => x.Name == model);
            return res;
        }

        public async Task CreateAsync(MBFormViewModel model, string id)
        {
            MotherBoard mb = new MotherBoard()
            {
                BuilderId = Guid.Parse(id),
                ImageUrl = model.ImageUrl,
                Name = model.Name,
                Price = model.Price,
                RamCapacity = model.RamCapacity,
                SocketId = model.SocketId,
                VendorId = model.VendorId,
            };

            await _dbContext.MotherBoards.AddAsync(mb);
            await _dbContext.SaveChangesAsync();

        }

        public async Task<IEnumerable<MBFormViewModel>> GetAllAsync()
        {
            IEnumerable<MBFormViewModel> list = await _dbContext
                 .MotherBoards
                 .Where(x => x.IsDeleted == false)
                 .Select(x => new MBFormViewModel()
                 {
                     Name = x.Name,
                     Id = x.Id,
                     Price = x.Price,
                     RamCapacity = x.RamCapacity,
                     SocketId = x.SocketId,
                     VendorId = x.VendorId,
                     ImageUrl = x.ImageUrl
                 }).ToListAsync();

            return list;

        }

        public async Task<MBDetailsViewModel?> GetMBDetailsAsync(int id)
        {
            MBDetailsViewModel? md = await _dbContext
                .MotherBoards
                .Where(x => x.Id == id)
                .Select(x => new MBDetailsViewModel()
                {
                    Name = x.Name,
                    Id = x.Id,
                    Price = x.Price,
                    RamCapacity = x.RamCapacity,
                    ImageUrl = x.ImageUrl,
                    SocketId = x.SocketId,
                    VendorId = x.VendorId,
                    SocketName = x.Socket.Name,
                    VendorName = x.Vendor.Name
                }).FirstOrDefaultAsync();

            return md;
        }

        public async Task<MBDetailsViewModel?> GetMBByIdAsync(int id)
        {
            MBDetailsViewModel? mb = await _dbContext
                .MotherBoards
                .Where(x => x.Id == id)
                .Select(x => new MBDetailsViewModel()
                {
                    Name = x.Name,
                    Id = x.Id,
                    Price = x.Price,
                    RamCapacity = x.RamCapacity,
                    ImageUrl = x.ImageUrl,
                    SocketName = x.Socket.Name,
                    VendorName = x.Vendor.Name,
                    VendorId = x.Vendor.Id,
                    SocketId = x.Socket.Id,
                }).FirstOrDefaultAsync();

            return mb;
        }
    }
}
