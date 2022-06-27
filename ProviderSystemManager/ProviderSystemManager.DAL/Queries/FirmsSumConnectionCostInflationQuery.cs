using ProviderSystemManager.DAL.Database;
using ProviderSystemManager.DAL.Queries.Interfaces;
using System.Data.Common;

namespace ProviderSystemManager.DAL.Queries
{
    public class FirmsSumConnectionCostInflationQuery : AbstractQuery<IEnumerable<FirmsSumConnectionCostInflationModel>>, IFirmsSumConnectionCostInflationQuery
    {
        public FirmsSumConnectionCostInflationQuery(ProviderDbContext dbContext) : base(dbContext)
        {
        }

        public override string CreateQuery => "create or replace function get_firms_sum_connection_cost_inflation(first_date date, second_date date) returns table(\"название\" varchar(40), \"до инфляции\" numeric, \"после инфляции\" numeric) as $$ begin return query select f.name, sum(c.connection_cost), 0.7 * sum(c.connection_cost) :: numeric from (select c.connection_cost, c.firm_id from contracts c where c.connection_date between first_date and second_date) c left join firms f on f.id = c.firm_id group by f.name; end; $$ language plpgsql;";

        protected override string ExecuteQuery => "SELECT * FROM get_firms_sum_connection_cost_inflation('{0}', '{1}')";

        protected override async Task<IEnumerable<FirmsSumConnectionCostInflationModel>> ConvertData(DbDataReader reader)
        {
            var list = new List<FirmsSumConnectionCostInflationModel>();

            while (await reader.ReadAsync())
            {
                list.Add(new(reader.GetString(0), reader.GetDouble(1), reader.GetDouble(2)));
            }

            return list;
        }
    }
}
