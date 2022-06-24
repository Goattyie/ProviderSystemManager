using ProviderSystemManager.DAL.Database;
using ProviderSystemManager.DAL.Queries.Interfaces;
using System.Data.Common;

namespace ProviderSystemManager.DAL.Queries
{
    public class FirmsByOwnType : AbstractQuery<IEnumerable<string>>, IFirmsByOwnType
    {
        public FirmsByOwnType(ProviderDbContext dbContext) : base(dbContext)
        {
        }

        public override string CreateQuery => "CREATE OR REPLACE FUNCTION get_firms_by_own_type(own_type TEXT) RETURNS TABLE(\"Название фирмы\" VARCHAR(40)) AS $$ BEGIN RETURN QUERY SELECT f.name	FROM firms f INNER JOIN own_types ot ON ot.id = f.own_type_id WHERE ot.name = own_type ORDER BY f.name;END;$$ LANGUAGE plpgsql;";
        protected override string ExecuteQuery => "SELECT * FROM get_firms_by_own_type('{0}')";
        protected override async Task<IEnumerable<string>> ConvertData(DbDataReader reader)
        {
            var list = new List<string>();

            while(await reader.ReadAsync())
            {
                list.Add(reader.GetString(0));
            }

            return list;
        }
    }
}
