using ProviderSystemManager.DAL.Database;
using ProviderSystemManager.DAL.Queries.Interfaces;
using System.Data.Common;

namespace ProviderSystemManager.DAL.Queries
{
    public class SumSizeFirmsQuery : AbstractQuery<IEnumerable<SumSizeFirmsModel>>, ISumSizeFirmsQuery
    {
        public SumSizeFirmsQuery(ProviderDbContext dbContext) : base(dbContext)
        {
        }

        public override string CreateQuery => "create or replace view get_sum_size_firms as select f.name, sum(s.size) from firms f join services s on s.firm_id = f.id group by f.name;";

        protected override string ExecuteQuery => "SELECT * FROM get_sum_size_firms";

        protected override async Task<IEnumerable<SumSizeFirmsModel>> ConvertData(DbDataReader reader)
        {
            var list = new List<SumSizeFirmsModel>();

            while (await reader.ReadAsync())
            {
                list.Add(new(reader.GetString(0), reader.GetDouble(1)));
            }

            return list;
        }
    }
}
