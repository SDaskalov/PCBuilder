namespace PCBuilder.Services.Contracts
{
    using PCBuilder.Web.ViewModels.CPU;
    public interface ICPUService
    {
        Task CreateAsync(CPUFormViewModel model);

        Task<bool> CPUExistsByModelName(string model);
    }
}
