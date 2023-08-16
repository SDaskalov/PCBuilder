﻿
namespace PCBuilder.Services
{
    using Microsoft.EntityFrameworkCore;
    using PCBuilder.Data;
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

        public Task CreateAsync(MBFormViewModel model, string id)
        {
            throw new NotImplementedException();
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
                    ImageUrl= x.ImageUrl,
                    SocketId= x.SocketId,
                    VendorId = x.VendorId,
                    SocketName=x.Socket.Name,
                    VendorName=x.Vendor.Name
                }).FirstOrDefaultAsync();

            return md;
        }
    }
}
