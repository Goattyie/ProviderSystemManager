using DevExpress.Mvvm;
using ProviderSystemManager.DAL.Queries.Interfaces;
using System.Collections.ObjectModel;

namespace ProviderSystemManager.WPF.ViewModels.Queries
{
    public class SumSizeFirmsQueryPageViewModel : BindableBase
    {
        private readonly ISumSizeFirmsQuery _query;

        public SumSizeFirmsQueryPageViewModel(ISumSizeFirmsQuery query)
        {
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
    }
}
