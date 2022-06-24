using DevExpress.Mvvm;
using ProviderSystemManager.DAL.Models.Queries;
using ProviderSystemManager.DAL.Queries.Interfaces;
using System.Collections.ObjectModel;

namespace ProviderSystemManager.WPF.ViewModels.Queries
{
    internal class ContractsInfoQueryPageViewModel : BindableBase
    {
        private readonly IContractsInfoQuery _query;

        public ContractsInfoQueryPageViewModel(IContractsInfoQuery query)
        {
            _query = query;
            Data = new ObservableCollection<ContractsInfo>();
        }

        public ObservableCollection<ContractsInfo> Data { get; set; }

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
