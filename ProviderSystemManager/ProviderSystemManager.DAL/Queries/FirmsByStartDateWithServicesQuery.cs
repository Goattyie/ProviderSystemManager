using ProviderSystemManager.DAL.Database;
using ProviderSystemManager.DAL.Models.Queries;
using ProviderSystemManager.DAL.Queries.Interfaces;
using System.Data.Common;

namespace ProviderSystemManager.DAL.Queries
{
    public class FirmsByStartDateWithServicesQuery : AbstractQuery<IEnumerable<FirmService>>, IFirmsByStartDateWithServicesQuery
    {
        public FirmsByStartDateWithServicesQuery(ProviderDbContext dbContext) : base(dbContext)
        {
        }

        public override string CreateQuery => "CREATE OR REPLACE FUNCTION get_firms_by_start_date_with_services(start_date INTEGER, end_date INTEGER) RETURNS TABLE(\"Название фирмы\" VARCHAR(40), \"Дата предоставления услуги\" DATE, \"Год открытия\" SMALLINT) AS $$ BEGIN 	RETURN QUERY 		SELECT f.name, s.recieving_date, f.start_working_year 		FROM firms f 		LEFT JOIN services s ON s.firm_id = f.id 		WHERE f.start_working_year BETWEEN start_date AND end_date AND s.id IS NOT NULL; END; $$ LANGUAGE plpgsql;";

        protected override string ExecuteQuery => "SELECT * FROM get_firms_by_start_date_with_services('{0}', '{1}')";

        protected override async Task<IEnumerable<FirmService>> ConvertData(DbDataReader reader)
        {
            var list = new List<FirmService>();

            while (await reader.ReadAsync())
            {
                list.Add(new()
                {
                    FirmName = reader.GetString(0),
                    RecievingDate = reader.GetDateTime(1),
                    StartWorkingDate = reader.GetInt32(2)
                });
            }

            return list;
        }
    }
}
