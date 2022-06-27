using ProviderSystemManager.DAL.Database;
using ProviderSystemManager.DAL.Queries.Interfaces;
using System.Data.Common;

namespace ProviderSystemManager.DAL.Queries
{
    public class AbonentsByContractsSumAndDateQuery : AbstractQuery<IEnumerable<AbonentByContractsSumModel>>, IAbonentsByContractsSumAndDateQuery
    {
        public AbonentsByContractsSumAndDateQuery(ProviderDbContext dbContext) : base(dbContext)
        {
        }

        public override string CreateQuery => "create or replace function get_abonents_by_contracts_sum_and_date(sum_value double precision, con_date date) returns table(\"имя\" text, \"сумма\" numeric) as $$ begin return query select a.name, sum(c.connection_cost) from contracts c join abonents a on a.id = c.abonent_id where c.connection_date=con_date group by a.name having sum(c.connection_cost) > sum_value; end; $$ language plpgsql;";

        protected override string ExecuteQuery => "SELECT * FROM get_abonents_by_contracts_sum_and_date({0}, '{1}')";

        protected override async Task<IEnumerable<AbonentByContractsSumModel>> ConvertData(DbDataReader reader)
        {
            var list = new List<AbonentByContractsSumModel>();

            while (await reader.ReadAsync())
            {
                list.Add(new(reader.GetString(0), reader.GetDouble(1)));
            }

            return list;
        }
    }
}
