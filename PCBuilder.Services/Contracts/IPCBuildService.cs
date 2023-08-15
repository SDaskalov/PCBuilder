namespace PCBuilder.Services.Contracts
{
    using PCBuilder.Web.ViewModels.Home;
    public interface IPCBuildService
    {
        Task<IEnumerable<PCBuildViewModel>> LastFourBuildsAsync();

    }
}
