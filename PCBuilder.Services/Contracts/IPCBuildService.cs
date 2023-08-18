namespace PCBuilder.Services.Contracts
{
    using PCBuilder.Web.ViewModels.CPU;
    using PCBuilder.Web.ViewModels.PCConfiguration;

    public interface IPCBuildService
    {
        Task<IEnumerable<PCBuildViewModel>> LastFourBuildsAsync();
        Task<PCBuildDetailsViewModel?> GetPCDetailsAsync(int id);

        Task BidForPcAsync(int id, string bidderid);

        Task SellPcAsync(int id, string bidderid);

        Task DisablePcAsync(int id, string bidderid);

        Task EnablePcAsync(int id, string bidderid);

        Task CheckSaleDateForPCAsync();

        Task CreateAsync(PCBuildCreateFormViewModel model, string id, string userid);

        Task<IEnumerable<PCBuildDetailsViewModel>> AllBuildsAsync();

        Task<IEnumerable<PCBuildDetailsViewModel>> AllBuildsForAdminAsync();

        Task<IEnumerable<PCBuildDetailsViewModel>> AllOwnedBuildsAsync(string id);

        Task<bool> CheckifPCExistsByIdAsync(int id);

        Task<PCBuildDetailsViewModel?> GetPCDetailsForAdminAsync(int id);

        Task<bool> CheckifPCExistsByIdForAdminAsync(int id);

        Task<bool> CheckifOwnedPCExistsByIdAsync(int id);

    }
}
