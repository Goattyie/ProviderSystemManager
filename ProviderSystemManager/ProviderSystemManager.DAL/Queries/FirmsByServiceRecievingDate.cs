using ProviderSystemManager.DAL.Database;
using ProviderSystemManager.DAL.Models.Queries;
using ProviderSystemManager.DAL.Queries.Interfaces;
using System.Data.Common;

namespace ProviderSystemManager.DAL.Queries
{
    public class FirmsByServiceRecievingDate : AbstractQuery<IEnumerable<FirmService>>, IFirmsByServiceRecievingDate
    {
        public FirmsByServiceRecievingDate(ProviderDbContext dbContext) : base(dbContext)
        {
        }

        public override string CreateQuery => "CREATE OR REPLACE FUNCTION get_firms_by_service_recieving_date(recieve_date date) RETURNS TABLE(\"Название фирмы\" VARCHAR(40), \"Объем сообщения\" DOUBLE PRECISION) AS $$ BEGIN 	RETURN QUERY 		SELECT f.name, s.size 		FROM firms f 		INNER JOIN services s ON s.firm_id = f.id 		WHERE s.recieving_date = recieve_date 		ORDER BY f.name; END; $$ LANGUAGE plpgsql;";

        protected override string ExecuteQuery => "SELECT * FROM get_firms_by_service_recieving_date('{0}');";

        protected override async Task<IEnumerable<FirmService>> ConvertData(DbDataReader reader)
        {
            var list = new List<FirmService>();

            while(await reader.ReadAsync())
            {
                list.Add(new()
                {
                    FirmName = reader.GetString(0),
                    Size = reader.GetDouble(1)
                });
            }

            return list;
        }
    }
}
