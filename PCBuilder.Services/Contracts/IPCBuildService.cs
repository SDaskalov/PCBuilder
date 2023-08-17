namespace PCBuilder.Services.Contracts
{
    using PCBuilder.Web.ViewModels.CPU;
    using PCBuilder.Web.ViewModels.PCConfiguration;

    public interface IPCBuildService
    {
        Task<IEnumerable<PCBuildViewModel>> LastFourBuildsAsync();
        Task<PCBuildDetailsViewModel?> GetPCDetailsAsync(int id);

        Task BidForPcAsync(int id, string bidderid);

        Task CheckSaleDateForPCAsync();

        Task CreateAsync(PCBuildCreateFormViewModel model, string id, string userid);

        Task<IEnumerable<PCBuildDetailsViewModel>> AllBuildsAsync();

        Task<bool> CheckifPCExistsByIdAsync(int id);

    }
}
