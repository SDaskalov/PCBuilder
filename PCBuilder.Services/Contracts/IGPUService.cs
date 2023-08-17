namespace PCBuilder.Services.Contracts
{
    using PCBuilder.Web.ViewModels.GPU;
    public interface IGPUService
    {

        Task CreateAsync(GPUFormViewModel model, string id);

        Task<bool> GPUExistsByModelName(string model);

        Task<IEnumerable<GPUFormViewModel>> GetAllAsync();

        Task<GPUFormViewModel?> GetGPUDetailsAsync(int id);

        Task<GPUFormViewModel?> GetGPUByIdAsync(int id);


    }
}
