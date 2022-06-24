using ProviderSystemManager.DAL.Database;
using ProviderSystemManager.DAL.Models.Queries;
using ProviderSystemManager.DAL.Queries.Interfaces;
using System.Data.Common;

namespace ProviderSystemManager.DAL.Queries
{
    public class ContractsInfoQuery : AbstractQuery<IEnumerable<ContractsInfo>>, IContractsInfoQuery
    {
        public ContractsInfoQuery(ProviderDbContext dbContext) : base(dbContext)
        {
        }

        public override string CreateQuery => "CREATE OR REPLACE VIEW get_contracts_info AS SELECT c.connection_cost, a.name FROM contracts c INNER JOIN abonents a ON a.id = c.abonent_id;";

        protected override string ExecuteQuery => "SELECT * FROM get_contracts_info;";

        protected override async Task<IEnumerable<ContractsInfo>> ConvertData(DbDataReader reader)
        {
            var list = new List<ContractsInfo>();

            while(await reader.ReadAsync())
            {
                list.Add(new()
                {
                    ConnectionCost = reader.GetDouble(0),
                    AbonentName = reader.GetString(1)
                });
            }

            return list;
        }
    }
}
