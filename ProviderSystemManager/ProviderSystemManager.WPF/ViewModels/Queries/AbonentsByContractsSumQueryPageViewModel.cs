using DevExpress.Mvvm;
using ProviderSystemManager.DAL.Queries.Interfaces;
using System.Collections.ObjectModel;

namespace ProviderSystemManager.WPF.ViewModels.Queries
{
    internal class AbonentsByContractsSumQueryPageViewModel : BindableBase
    {
        private readonly IAbonentsByContractsSumQuery _query;

        public AbonentsByContractsSumQueryPageViewModel(IAbonentsByContractsSumQuery query)
        {
            _query = query;
            Data = new();
        }

        public ObservableCollection<AbonentByContractsSumModel> Data { get; set; }
        public int? Count { get; set; }

        public IAsyncCommand Execute => new AsyncCommand(async () =>
        {
            var result = await _query.Execute(Count?.ToString());

            Data.Clear();

            foreach (var item in result)
            {
                Data.Add(item);
            }
        });
    }
}
