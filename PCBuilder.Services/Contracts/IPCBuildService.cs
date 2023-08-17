namespace PCBuilder.Services.Contracts
{
    using PCBuilder.Web.ViewModels.PCConfiguration;

    public interface IPCBuildService
    {
        Task<IEnumerable<PCBuildViewModel>> LastFourBuildsAsync();
        Task<PCBuildDetailsViewModel?> GetPCDetailsAsync(int id);

        Task BidForPcAsync(int id, string bidderid);

        Task CheckSaleDateForPCAsync();
    }
}
