using DevExpress.Mvvm;
using ProviderSystemManager.DAL.Queries.Interfaces;
using System.Collections.ObjectModel;

namespace ProviderSystemManager.WPF.ViewModels.Queries
{
    internal class CaseQueryPageViewModel : BindableBase
    {
        private readonly IСaseQuery _query;

        public CaseQueryPageViewModel(IСaseQuery query)
        {
            _query = query;
            Data = new();
        }
        public ObservableCollection<double> Data { get; set; }
        public string Value { get; set; }

        public IAsyncCommand Execute => new AsyncCommand(async () =>
        {
            var result = await _query.Execute(Value);

            Data.Clear();
            Data.Add(result);
        });
    }
}
