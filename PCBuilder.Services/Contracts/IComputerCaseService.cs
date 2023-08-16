namespace PCBuilder.Services.Contracts
{
    using PCBuilder.Web.ViewModels.ComputerCase;


    public interface IComputerCaseService
    {
        Task CreateAsync(ComputerCaseFormViewModel model, string id);

        Task<bool> CaseExistsByModelName(string model);

        Task<IEnumerable<ComputerCaseFormViewModel>> GetAllAsync();

        Task<ComputerCaseFormViewModel?> GetCaseDetailsAsync(int id);

        Task<ComputerCaseFormViewModel?> GetCaseByIdAsync(int id);
    }
}
