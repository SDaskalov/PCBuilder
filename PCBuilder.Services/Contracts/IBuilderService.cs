namespace PCBuilder.Services.Contracts
{
    public interface IBuilderService
    {
        Task<bool>  BuilderAlreadyExcistsByUserId(string userId);
    }
}
