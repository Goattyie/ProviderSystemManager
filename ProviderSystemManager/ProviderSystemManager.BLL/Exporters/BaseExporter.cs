using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.UserModel.Charts;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using ProviderSystemManager.BLL.Exporters.Utils;
using System.Data;


namespace ProviderSystemManager.BLL.Exporters
{
    public class BaseExporter
    {
        public async Task<Stream> ExportTable(DataTable table, ChartOptions chartOptions = null)
        {
            var stream = new FileStream($"{DateTime.Now.Millisecond}.xlsx", FileMode.Create, FileAccess.Write);
            var workbook = new XSSFWorkbook();
            var sheet = workbook.CreateSheet();
            var headerRow = sheet.CreateRow(0);

            for (var i = 0; i < table.Columns.Count; i++)
            {
                var cell = headerRow.CreateCell(i);
                cell.SetCellValue(table.Columns[i].Caption);
            }

            for (var i = 0; i < table.Rows.Count; i++)
            {
                var dataRow = sheet.CreateRow(i + 1);
                for (var j = 0; j < table.Columns.Count; j++)
                {
                    var cell = dataRow.CreateCell(j);
                    var value = table.Rows[i][j].ToString();

                    if (table.Columns[j].DataType == typeof(double))
                    {
                        cell.SetCellValue(double.Parse(value));
                    }
                    else
                    {
                        cell.SetCellValue(value);
                    }
                }
            }

            if (chartOptions is not null)
                GenerageBarChart(sheet, chartOptions);

            workbook.Write(stream);
            stream.Position = 0;
            stream.Close();

            return null;
        }

        private void GenerageBarChart(ISheet sheet, ChartOptions options)
        {
            var drawing = (XSSFDrawing)sheet.CreateDrawingPatriarch();
            var anchor = (XSSFClientAnchor)drawing.CreateAnchor(0, 0, 0, 0, 3, 0, 20, 21);
            var chart = (XSSFChart)drawing.CreateChart(anchor);
            var barChartData = chart.ChartDataFactory.CreateBarChartData<string, double>();
            var legend = chart.GetOrCreateLegend();
            
            legend.Position = LegendPosition.Bottom;

            var bottomAxis = chart.ChartAxisFactory.CreateCategoryAxis(AxisPosition.Bottom);
            
            bottomAxis.MajorTickMark = AxisTickMark.None;
            
            var leftAxis = chart.ChartAxisFactory.CreateValueAxis(AxisPosition.Left);
            
            leftAxis.Crosses = AxisCrosses.AutoZero;
            leftAxis.SetCrossBetween(AxisCrossBetween.Between);


            var categoryAxis = DataSources.FromStringCellRange(sheet, new CellRangeAddress(options.FirstRow, options.FirstRow + options.RowCount, options.TitleCol, options.TitleCol));
            var valueAxis = DataSources.FromNumericCellRange(sheet, new CellRangeAddress(options.FirstRow, options.FirstRow + options.RowCount, options.ValueCol, options.ValueCol));
            var serie = barChartData.AddSeries(categoryAxis, valueAxis);
            
            serie.SetTitle(options.ChartName);

            chart.Plot(barChartData, bottomAxis, leftAxis);
        }
    }
}
