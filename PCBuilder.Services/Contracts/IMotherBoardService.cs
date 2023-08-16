namespace PCBuilder.Services.Contracts
{
    using PCBuilder.Web.ViewModels.CPU;
    using PCBuilder.Web.ViewModels.Motherboard;

    public interface IMotherBoardService
    {
        Task CreateAsync(MBFormViewModel model, string id);

        Task<bool> MBExistsByModelName(string model);

        Task<IEnumerable<MBFormViewModel>> GetAllAsync();

        Task<MBDetailsViewModel?> GetMBDetailsAsync(int id);

        Task<MBDetailsViewModel?> GetMBByIdAsync(int id);
    }
}
