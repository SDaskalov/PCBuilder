namespace PCBuilder.Services.Contracts
{
    using PCBuilder.Web.ViewModels.Sockets;
    public interface ISocketCategoryService
    {
        Task<IEnumerable<SocketCategoryFormModel>> GetAllSocketCategoriesAsync();
    }
}
