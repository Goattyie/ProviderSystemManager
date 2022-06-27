using ProviderSystemManager.DAL.Database;
using ProviderSystemManager.DAL.Queries.Interfaces;
using System.Data.Common;

namespace ProviderSystemManager.DAL.Queries
{
    public class FirmsCountByOwnTypeQuery : AbstractQuery<int>, IFirmsCountByOwnTypeQuery
    {
        public FirmsCountByOwnTypeQuery(ProviderDbContext dbContext) : base(dbContext)
        {
        }

        public override string CreateQuery => "create or replace function get_firms_count_by_own_type(own_type_name text) returns table(\"количество\" bigint) as $$ begin return query select count(f.name) from firms f join own_types ot on f.own_type_id = ot.id where ot.name = own_type_name group by ot.name; end; $$ language plpgsql;";

        protected override string ExecuteQuery => "SELECT * FROM get_firms_count_by_own_type('{0}')";

        protected override async Task<int> ConvertData(DbDataReader reader)
        {
            while (await reader.ReadAsync())
            {
                return reader.GetInt32(0);
            }

            return 0;
        }
    }
}
