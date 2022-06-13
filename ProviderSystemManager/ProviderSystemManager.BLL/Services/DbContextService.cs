using Microsoft.EntityFrameworkCore;
using ProviderSystemManager.BLL.Localization;
using ProviderSystemManager.DAL.Database;
using ProviderSystemManager.BLL.Services.Interfaces;
using ProviderSystemManager.Shared;

namespace ProviderSystemManager.BLL.Services
{
    public class DbContextService : IDbContextService
    {
        private readonly ProviderDbContext _dbContext;

        public DbContextService(ProviderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<bool>> ChangeConnectionAsync(string connectionString)
        {
            _dbContext.Database.SetConnectionString(connectionString);

            var canConnect = await _dbContext.Database.CanConnectAsync();

            return canConnect ? OperationResponse.Ok(canConnect) : OperationResponse.Bad<bool>(Errors.ConnectionFail);
        }
    }
}