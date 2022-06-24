using ProviderSystemManager.DAL.Database;
using ProviderSystemManager.DAL.Models.Queries;
using ProviderSystemManager.DAL.Queries.Interfaces;
using System.Data.Common;

namespace ProviderSystemManager.DAL.Queries
{
    public class FirmHaveServicesQuery : AbstractQuery<IEnumerable<FirmService>>, IFirmHaveServicesQuery
    {
        public FirmHaveServicesQuery(ProviderDbContext dbContext) : base(dbContext)
        {
        }

        public override string CreateQuery => "CREATE OR REPLACE VIEW get_firms_have_services AS SELECT f.name AS \"Название компании\", s.recieving_date \"Дата предоставления услуги\"  FROM services s RIGHT OUTER JOIN firms f ON f.id = s.firm_id WHERE s.id IS NOT NULL;";

        protected override string ExecuteQuery => "SELECT * FROM get_firms_have_services";

        protected override async Task<IEnumerable<FirmService>> ConvertData(DbDataReader reader)
        {
            var list = new List<FirmService>();

            while (await reader.ReadAsync())
            {
                list.Add(new()
                {
                    FirmName = reader.GetString(0),
                    RecievingDate = reader.GetDateTime(1)
                });
            }

            return list;
        }
    }
}
