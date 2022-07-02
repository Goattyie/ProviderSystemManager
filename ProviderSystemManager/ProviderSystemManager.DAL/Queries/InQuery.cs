using ProviderSystemManager.DAL.Database;
using ProviderSystemManager.DAL.Queries.Interfaces;
using System.Data.Common;

namespace ProviderSystemManager.DAL.Queries
{
    public class InQuery : AbstractQuery<IEnumerable<InModel>>, IInQuery
    {
        public InQuery(ProviderDbContext dbContext) : base(dbContext)
        {
        }

        public override string CreateQuery => "CREATE OR REPLACE FUNCTION in_query(own_type TEXT) RETURNS TABLE(\"#\" INTEGER, \"Дата подключения\" DATE, \"Абонент\" TEXT, \"Email\" TEXT) AS $$ BEGIN RETURN QUERY SELECT c.id, c.connection_date, a.name, a.email FROM contracts c JOIN abonents a ON a.id = c.abonent_id WHERE c.firm_id IN (SELECT f.id FROM firms f JOIN own_types ot ON ot.id = f.own_type_id WHERE ot.name = own_type); END; $$ LANGUAGE plpgsql;";

        protected override string ExecuteQuery => "SELECT * FROM in_query('{0}')";

        protected override async Task<IEnumerable<InModel>> ConvertData(DbDataReader reader)
        {
            var list = new List<InModel>();

            while (await reader.ReadAsync())
            {
                list.Add(new(reader.GetInt32(0), reader.GetDateTime(1), reader.GetString(2), reader.GetString(3)));
            }

            return list;
        }
    }

    public class NotInQuery : AbstractQuery<IEnumerable<InModel>>, INotInQuery
    {
        public NotInQuery(ProviderDbContext dbContext) : base(dbContext)
        {
        }

        public override string CreateQuery => "CREATE OR REPLACE FUNCTION in_query(own_type TEXT) RETURNS TABLE(\"#\" INTEGER, \"Дата подключения\" DATE, \"Абонент\" TEXT, \"Email\" TEXT) AS $$ BEGIN RETURN QUERY SELECT c.id, c.connection_date, a.name, a.email FROM contracts c JOIN abonents a ON a.id = c.abonent_id WHERE c.firm_id NOT IN (SELECT f.id FROM firms f JOIN own_types ot ON ot.id = f.own_type_id WHERE ot.name = own_type); END; $$ LANGUAGE plpgsql;";

        protected override string ExecuteQuery => "SELECT * FROM in_query('{0}')";

        protected override async Task<IEnumerable<InModel>> ConvertData(DbDataReader reader)
        {
            var list = new List<InModel>();

            while (await reader.ReadAsync())
            {
                list.Add(new(reader.GetInt32(0), reader.GetDateTime(1), reader.GetString(2), reader.GetString(3)));
            }

            return list;
        }
    }
}
