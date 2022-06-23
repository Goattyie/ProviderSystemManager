using Microsoft.EntityFrameworkCore;
using ProviderSystemManager.DAL.Database;
using ProviderSystemManager.DAL.Queries;

namespace ProviderSystemManager.DAL.QueryCreators
{
    internal class QueryCreator
    {
        public static void Init(ProviderDbContext dbContext)
        {
            var query = new GetEmailsByAbonentTypeQuery(dbContext);
            dbContext.Database.ExecuteSqlRaw(query.CreateQuery);
        }
    }
}
