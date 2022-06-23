using Microsoft.EntityFrameworkCore;
using ProviderSystemManager.DAL.Database;
using System.Data.Common;

namespace ProviderSystemManager.DAL.Queries.Interfaces
{
    public abstract class AbstractQuery<TOut> : IQuery<TOut>
    {
        private readonly ProviderDbContext _dbContext;

        public AbstractQuery(ProviderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public abstract string CreateQuery { get; }
        protected abstract string ExecuteQuery { get; }
        protected abstract Task<TOut> ConvertData(DbDataReader reader);

        public async Task<TOut> Execute(params string[] @params)
        {
            using var command = _dbContext.Database.GetDbConnection().CreateCommand();

            command.CommandText = string.Format(ExecuteQuery, @params);
            await _dbContext.Database.OpenConnectionAsync();

            using var result = await command.ExecuteReaderAsync();

            return await ConvertData(result);
        }
    }
           
}
