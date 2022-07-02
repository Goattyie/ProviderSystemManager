using ProviderSystemManager.DAL.Database;
using ProviderSystemManager.DAL.Queries.Interfaces;
using System.Data.Common;

namespace ProviderSystemManager.DAL.Queries
{
    public class UnionQuery : AbstractQuery<IEnumerable<UnionModel>>, IUnionQuery
    {
        public UnionQuery(ProviderDbContext dbContext) : base(dbContext)
        {
        }

        public override string CreateQuery => "CREATE OR REPLACE VIEW union_query AS (SELECT 'Контракты' \"Тип\", COUNT(s.id) \"Количество\" FROM services s) UNION (SELECT 'Услуги' \"Тип\", COUNT(c.id) \"Количество\" FROM contracts c);";

        protected override string ExecuteQuery => "SELECT * FROM union_query";

        protected override async Task<IEnumerable<UnionModel>> ConvertData(DbDataReader reader)
        {
            var list = new List<UnionModel>();

            while (await reader.ReadAsync())
            {
                list.Add(new(reader.GetString(0), reader.GetInt32(1)));
            }

            return list;
        }
    }
}
