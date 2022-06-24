using ProviderSystemManager.DAL.Database;
using ProviderSystemManager.DAL.Models.Queries;
using ProviderSystemManager.DAL.Queries.Interfaces;
using System.Data.Common;

namespace ProviderSystemManager.DAL.Queries
{
    public class ContractAbonentsEmailNotNullQuery : AbstractQuery<IEnumerable<ContractsInfo>>, IContractAbonentsEmailNotNullQuery
    {
        public ContractAbonentsEmailNotNullQuery(ProviderDbContext dbContext) : base(dbContext)
        {
        }

        public override string CreateQuery => "CREATE OR REPLACE VIEW get_contract_abonents_email_not_null AS SELECT c.connection_cost, a.name, a.email FROM contracts c LEFT OUTER JOIN abonents a ON a.id = c.abonent_id WHERE a.email IS NOT NULL;";

        protected override string ExecuteQuery => "SELECT * FROM get_contract_abonents_email_not_null;";

        protected override async Task<IEnumerable<ContractsInfo>> ConvertData(DbDataReader reader)
        {
            var list = new List<ContractsInfo>();

            while (await reader.ReadAsync())
            {
                list.Add(new()
                {
                    ConnectionCost = reader.GetDouble(0),
                    AbonentName = reader.GetString(1),
                    Email = reader.GetString(2)
                });
            }

            return list;
        }
    }
}
