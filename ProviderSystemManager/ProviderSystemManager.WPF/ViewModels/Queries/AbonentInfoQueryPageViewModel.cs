using DevExpress.Mvvm;
using ProviderSystemManager.DAL.Queries.Interfaces;
using System.Collections.ObjectModel;

namespace ProviderSystemManager.WPF.ViewModels.Queries
{
    internal class AbonentInfoQueryPageViewModel : BindableBase
    {
        private readonly IAbonentInfoQuery _query;

        public AbonentInfoQueryPageViewModel(IAbonentInfoQuery query)
        {
            _query = query;
            Data = new();
        }

        public ObservableCollection<AbonentInfoModel> Data { get; set; }

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
