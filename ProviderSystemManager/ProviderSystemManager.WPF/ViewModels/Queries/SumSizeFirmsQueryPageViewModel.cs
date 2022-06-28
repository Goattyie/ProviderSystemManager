using DevExpress.Mvvm;
using ProviderSystemManager.BLL.Exporters.Interfaces;
using ProviderSystemManager.DAL.Queries.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace ProviderSystemManager.WPF.ViewModels.Queries
{
    public class SumSizeFirmsQueryPageViewModel : BindableBase
    {
        private readonly IExporter<IEnumerable<SumSizeFirmsModel>> _exporter;
        private readonly ISumSizeFirmsQuery _query;

        public SumSizeFirmsQueryPageViewModel(ISumSizeFirmsQuery query, IExporter<IEnumerable<SumSizeFirmsModel>> exporter)
        {
            _exporter = exporter;
            _query = query;
            Data = new();
        }

        public ObservableCollection<SumSizeFirmsModel> Data { get; set; }

        public IAsyncCommand Execute => new AsyncCommand(async () =>
        {
            var result = await _query.Execute();

            Data.Clear();

            foreach (var item in result)
            {
                Data.Add(item);
            }
        });

        public IAsyncCommand ToExcel => new AsyncCommand(async () =>
        {
            var result = await _query.Execute();

            var stream = await _exporter.Export(result);

            //using var filestream = new FileStream($"{DateTime.Now.Millisecond}.xlsx", FileMode.Create, System.IO.FileAccess.Write);
            //await stream.CopyToAsync(filestream);
            //stream.Close();
        });
    }
}
