using ProviderSystemManager.DAL.Database;
using ProviderSystemManager.DAL.Queries.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderSystemManager.DAL.Queries
{
    public class MaskQuery : AbstractQuery<IEnumerable<MaskModel>>, IMaskQuery
    {
        public MaskQuery(ProviderDbContext dbContext) : base(dbContext)
        {
        }

        public override string CreateQuery => "CREATE OR REPLACE FUNCTION mask_query(f_name TEXT) RETURNS TABLE(\"Тип собственности\" VARCHAR(20), \"Количество фирм\" BIGINT) AS $$ BEGIN RETURN QUERY SELECT ot.name, COUNT(f.name) FROM firms f JOIN own_types ot ON ot.id = f.own_type_id WHERE f.name LIKE '%' || f_name || '%' GROUP BY ot.name; END; $$ LANGUAGE plpgsql;";

        protected override string ExecuteQuery => "SELECT * FROM mask_query('{0}')";

        protected override async Task<IEnumerable<MaskModel>> ConvertData(DbDataReader reader)
        {
            var list = new List<MaskModel>();

            while (await reader.ReadAsync())
            {
                list.Add(new(reader.GetString(0), reader.GetInt32(1)));
            }

            return list;
        }
    }
}
