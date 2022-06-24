using ProviderSystemManager.DAL.Database;
using ProviderSystemManager.DAL.Models.Queries;
using ProviderSystemManager.DAL.Queries.Interfaces;
using System.Data.Common;

namespace ProviderSystemManager.DAL.Queries
{
    public class ServiceInfoQuery : AbstractQuery<IEnumerable<ServiceInfo>>, IServiceInfoQuery
    {
        public ServiceInfoQuery(ProviderDbContext dbContext) : base(dbContext)
        {
        }

        public override string CreateQuery => "CREATE OR REPLACE VIEW get_service_info AS SELECT s.size, a.name FROM services s INNER JOIN abonents a ON a.id = s.abonent_id;";

        protected override string ExecuteQuery => "SELECT * FROM get_service_info;";

        protected override async Task<IEnumerable<ServiceInfo>> ConvertData(DbDataReader reader)
        {
            var list = new List<ServiceInfo>();

            while(await reader.ReadAsync())
            {
                list.Add(new()
                {
                    Size = reader.GetDouble(0),
                    AbonentName = reader.GetString(1)
                });
            }

            return list;
        }
    }
}
