using DevExpress.Mvvm;
using ProviderSystemManager.DAL.Models.Queries;
using ProviderSystemManager.DAL.Queries.Interfaces;
using System.Collections.ObjectModel;

namespace ProviderSystemManager.WPF.ViewModels.Queries
{
    internal class FirmHaveServicesQueryPageViewModel : BindableBase
    {
        private readonly IFirmHaveServicesQuery _query;

        public FirmHaveServicesQueryPageViewModel(IFirmHaveServicesQuery query)
        {
            _query = query;
            Data = new ObservableCollection<FirmService>();
        }

        public ObservableCollection<FirmService> Data { get; set; }

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
