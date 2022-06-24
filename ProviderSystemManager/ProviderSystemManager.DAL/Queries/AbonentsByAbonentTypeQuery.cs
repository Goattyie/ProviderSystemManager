using Microsoft.EntityFrameworkCore;
using ProviderSystemManager.DAL.Database;
using ProviderSystemManager.DAL.Models.Queries;
using ProviderSystemManager.DAL.Queries.Interfaces;
using System.Data.Common;

namespace ProviderSystemManager.DAL.Queries
{
    public class AbonentsByAbonentTypeQuery : AbstractQuery<IEnumerable<EmailsByAbonentTypeModel>>, IAbonentsByAbonentTypeQuery
    {
        public AbonentsByAbonentTypeQuery(ProviderDbContext dbContext) : base(dbContext)
        {
        }

        public override string CreateQuery => "CREATE OR REPLACE FUNCTION get_abonents_by_abonent_type(abonent_type TEXT) RETURNS TABLE(\"Имя\" TEXT, \"Почта\" TEXT) AS $$ BEGIN RETURN QUERY SELECT a.name, a.email FROM abonents a INNER JOIN abonent_types abt ON abt.id = a.abonent_type_id WHERE abt.name = abonent_type ORDER BY a.name; END; $$ LANGUAGE plpgsql;";

        protected override string ExecuteQuery => "SELECT * FROM get_abonents_by_abonent_type('{0}')";

        protected override async Task<IEnumerable<EmailsByAbonentTypeModel>> ConvertData(DbDataReader reader)
        {
            var list = new List<EmailsByAbonentTypeModel>();

            while (await reader.ReadAsync())
            {
                list.Add(new()
                {
                    Name = reader.GetString(0),
                    Email = reader.GetString(1)
                });
            }

            return list;
        }
    }
}
