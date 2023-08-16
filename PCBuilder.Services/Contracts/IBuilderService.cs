using PCBuilder.Web.ViewModels.Builder;
using System.Globalization;

namespace PCBuilder.Services.Contracts
{
    public interface IBuilderService
    {
        Task<bool>  BuilderAlreadyExcistsByUserId(string userId);

        Task<bool> BuilderNameIsTaken(string name);

        Task Create(string userId, BecomeBuilderFormModel model);

        Task<bool> HasPCWithIdAsync(string? userId, string houseId);
    }
}
