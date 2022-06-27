using Microsoft.EntityFrameworkCore;
using ProviderSystemManager.DAL.Database;
using ProviderSystemManager.DAL.Queries;

namespace ProviderSystemManager.DAL.QueryCreators
{
    internal class QueryCreator
    {
        public static void Init(ProviderDbContext dbContext)
        {
            var query = new AbonentsByAbonentTypeQuery(dbContext);
            var query2 = new FirmsByOwnType(dbContext);
            var query3 = new FirmsByServiceRecievingDate(dbContext);
            var query4 = new ContractsInfoQuery(dbContext);
            var query5 = new ServiceInfoQuery(dbContext);
            var query6 = new ContractAbonentsEmailNotNullQuery(dbContext);
            var query7 = new FirmHaveServicesQuery(dbContext);
            var query8 = new FirmsByStartDateWithServicesQuery(dbContext);
            var query9 = new AbonentsByServiceRecievingDateQuery(dbContext);
            var query10 = new AbonentInfoQuery(dbContext);

            dbContext.Database.ExecuteSqlRaw(query.CreateQuery);
            dbContext.Database.ExecuteSqlRaw(query2.CreateQuery);
            dbContext.Database.ExecuteSqlRaw(query3.CreateQuery);
            dbContext.Database.ExecuteSqlRaw(query4.CreateQuery);
            dbContext.Database.ExecuteSqlRaw(query5.CreateQuery);
            dbContext.Database.ExecuteSqlRaw(query6.CreateQuery);
            dbContext.Database.ExecuteSqlRaw(query7.CreateQuery);
            dbContext.Database.ExecuteSqlRaw(query8.CreateQuery);
            dbContext.Database.ExecuteSqlRaw(query9.CreateQuery);
            dbContext.Database.ExecuteSqlRaw(query10.CreateQuery);
        }
    }
}
