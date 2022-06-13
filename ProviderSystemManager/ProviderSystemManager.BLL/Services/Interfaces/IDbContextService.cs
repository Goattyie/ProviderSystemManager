using ProviderSystemManager.Shared;

namespace ProviderSystemManager.BLL.Services.Interfaces
{
    public interface IDbContextService
    {
        public Task<OperationResult<bool>> ChangeConnectionAsync(string connectionString);
    }
}
