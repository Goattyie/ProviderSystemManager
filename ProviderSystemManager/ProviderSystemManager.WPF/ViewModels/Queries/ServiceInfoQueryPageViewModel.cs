using DevExpress.Mvvm;
using ProviderSystemManager.DAL.Models.Queries;
using ProviderSystemManager.DAL.Queries.Interfaces;
using System.Collections.ObjectModel;

namespace ProviderSystemManager.WPF.ViewModels.Queries
{
    internal class ServiceInfoQueryPageViewModel
    {
        public ServiceInfoQueryPageViewModel(IServiceInfoQuery query)
        {
            _query = query;
            Data = new ObservableCollection<ServiceInfo>();
        }

        private readonly IServiceInfoQuery _query;

        public ObservableCollection<ServiceInfo> Data { get; set; }

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
