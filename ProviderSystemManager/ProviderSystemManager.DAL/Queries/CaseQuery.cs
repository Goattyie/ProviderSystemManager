using ProviderSystemManager.DAL.Database;
using ProviderSystemManager.DAL.Queries.Interfaces;
using System.Data.Common;

namespace ProviderSystemManager.DAL.Queries
{
    public class СaseQuery : AbstractQuery<double>, IСaseQuery
    {
        public СaseQuery(ProviderDbContext dbContext) : base(dbContext)
        {
        }

        public override string CreateQuery => "CREATE OR REPLACE FUNCTION case_query(f_name TEXT) RETURNS TABLE(\"Средняя стоимость\" FLOAT8) AS $$ BEGIN RETURN QUERY SELECT avg(CASE WHEN f.name = f_name THEN c.connection_cost END)::FLOAT8 FROM contracts c JOIN firms f ON f.id = c.firm_id WHERE f.name = f_name GROUP BY f.name; END; $$ LANGUAGE plpgsql;";

        protected override string ExecuteQuery => "SELECT * FROM case_query('{0}')";

        protected override async Task<double> ConvertData(DbDataReader reader)
        {
            while (await reader.ReadAsync())
            {
                return reader.GetDouble(0);
            }

            return 0;
        }
    }
}
