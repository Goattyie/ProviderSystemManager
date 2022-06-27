using ProviderSystemManager.DAL.Database;
using ProviderSystemManager.DAL.Queries.Interfaces;
using System.Data.Common;

namespace ProviderSystemManager.DAL.Queries
{
    public class FirmsSumConnectionCostMoreAvgQuery : AbstractQuery<IEnumerable<FirmsSumConnectionCostMoreAvgModel>>, IFirmsSumConnectionCostMoreAvgQuery
    {
        public FirmsSumConnectionCostMoreAvgQuery(ProviderDbContext dbContext) : base(dbContext)
        {
        }

        public override string CreateQuery => "create or replace view get_firms_sum_connection_cost_more_avg as select f.name, sum(c.connection_cost) from firms f join contracts c on c.firm_id = f.id where c.connection_cost > (select avg(contracts.connection_cost) from contracts) group by f.name;";

        protected override string ExecuteQuery => "SELECT * FROM get_firms_sum_connection_cost_more_avg";

        protected override async Task<IEnumerable<FirmsSumConnectionCostMoreAvgModel>> ConvertData(DbDataReader reader)
        {
            var list = new List<FirmsSumConnectionCostMoreAvgModel>();

            while (await reader.ReadAsync())
            {
                list.Add(new(reader.GetString(0), reader.GetDouble(1)));
            }

            return list;
        }
    }
}
