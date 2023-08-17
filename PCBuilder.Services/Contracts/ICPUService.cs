namespace PCBuilder.Services.Contracts
{
    using PCBuilder.Web.ViewModels.CPU;
 

    public interface ICPUService
    {
        Task CreateAsync(CPUFormViewModel model,string id);

        Task<bool> CPUExistsByModelName(string model);

        Task<IEnumerable<CPUFormViewModel>> GetAllAsync();

        Task<CPUDetailsViewModel?> GetCPUDetailsAsync(int id);

        Task<CPUDetailsViewModel?> GetCPUByIdAsync(int id);

        Task<IEnumerable<CPUDetailsViewModel>> GetAllCPUCategoriesAsync();
    }
}
