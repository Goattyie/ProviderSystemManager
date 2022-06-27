using DevExpress.Mvvm;
using ProviderSystemManager.DAL.Queries.Interfaces;
using System.Collections.ObjectModel;

namespace ProviderSystemManager.WPF.ViewModels.Queries
{
    internal class FirmsSumConnectionCostMoreAvgQueryPageViewModel : BindableBase
    {
        private readonly IFirmsSumConnectionCostMoreAvgQuery _query;

        public FirmsSumConnectionCostMoreAvgQueryPageViewModel(IFirmsSumConnectionCostMoreAvgQuery query)
        {
            _query = query;
            Data = new();
        }

        public ObservableCollection<FirmsSumConnectionCostMoreAvgModel> Data { get; set; }

        public IAsyncCommand Execute => new AsyncCommand(async () =>
        {
            var result = await _query.Execute();

            Data.Clear();

            foreach (var item in result)
            {
                Data.Add(item);
            }
        });
    }
}
