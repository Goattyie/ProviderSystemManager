using ProviderSystemManager.BLL.Exporters.Interfaces;
using ProviderSystemManager.BLL.Exporters.Utils;
using ProviderSystemManager.DAL.Queries.Interfaces;
using System.Data;

namespace ProviderSystemManager.BLL.Exporters.QueryExporters
{
    public class SumSizeFirmsQueryExporter : BaseExporter, IExporter<IEnumerable<SumSizeFirmsModel>>
    {
        public async Task<Stream> Export(IEnumerable<SumSizeFirmsModel> data)
        {
            var table = new DataTable();

            table.Columns.Add(new DataColumn("Фирма", typeof(string)));
            table.Columns.Add(new DataColumn("Общее число МБ", typeof(double)));

            foreach (var obj in data)
            {
                table.Rows.Add(obj.FirmName, obj.SumSize);
            }

            var chartOptions = new ChartOptions() { ChartName = "Общий объем поставленных мегабайт", FirstRow = 1, RowCount = data.Count() - 1, TitleCol = 0, ValueCol = 1 };

            return await ExportTable(table, chartOptions);
        }
    }
}
