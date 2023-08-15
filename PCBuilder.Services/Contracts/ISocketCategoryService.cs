namespace PCBuilder.Services.Contracts
{
    using PCBuilder.Web.ViewModels.Sockets;
    public interface ISocketCategoryService
    {
        Task<IEnumerable<SocketCategoryFormModel>> GetAllSocketCategoriesAsync();
        Task<bool> SocketExistsById(int id);
    }
}
