using ProviderSystemManager.DAL.Database;
using ProviderSystemManager.DAL.Queries.Interfaces;
using System.Data.Common;

namespace ProviderSystemManager.DAL.Queries
{
    public class AbonentInfoQuery : AbstractQuery<IEnumerable<AbonentInfoModel>>, IAbonentInfoQuery
    {
        public AbonentInfoQuery(ProviderDbContext dbContext) : base(dbContext)
        {
        }

        public override string CreateQuery => "create or replace view get_abonent_info as select a.name as \"абонент\", atp.name as \"тип\" from abonents a inner join abonent_types atp on atp.id = a.abonent_type_id;";

        protected override string ExecuteQuery => "SELECT * FROM get_abonent_info";

        protected override async Task<IEnumerable<AbonentInfoModel>> ConvertData(DbDataReader reader)
        {
            var list = new List<AbonentInfoModel>();

            while (await reader.ReadAsync())
            {
                list.Add(new(reader.GetString(0), reader.GetString(1)));
            }

            return list;
        }
    }
}
