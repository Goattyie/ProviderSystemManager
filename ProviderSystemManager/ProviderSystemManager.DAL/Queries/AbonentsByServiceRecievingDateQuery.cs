using ProviderSystemManager.DAL.Database;
using ProviderSystemManager.DAL.Queries.Interfaces;
using System.Data.Common;

namespace ProviderSystemManager.DAL.Queries
{
    public class AbonentsByServiceRecievingDateQuery : AbstractQuery<IEnumerable<AbonentsByServiceRecievingDateModel>>, IAbonentsByServiceRecievingDateQuery
    {
        public AbonentsByServiceRecievingDateQuery(ProviderDbContext dbContext) : base(dbContext)
        {
        }

        public override string CreateQuery => "create	or	replace	function	get_abonents_by_service_recieving_date(recieve_date	date) returns	table(\"имя\"	text,	\"объем	сообщения\"	double	precision) as	$$ begin return	query select	a.name,	s.size from	abonents	a inner	join	services	s	on	s.abonent_id	=	a.id where	s.recieving_date	=	recieve_date order	by	a.name; end; $$	language	plpgsql;";

        protected override string ExecuteQuery => "SELECT* FROM get_abonents_by_service_recieving_date('{0}');";

        protected override async Task<IEnumerable<AbonentsByServiceRecievingDateModel>> ConvertData(DbDataReader reader)
        {
            var list = new List<AbonentsByServiceRecievingDateModel>();

            while (await reader.ReadAsync())
            {
                list.Add(new(reader.GetString(0), reader.GetDouble(1)));
            }

            return list;
        }
    }
}
