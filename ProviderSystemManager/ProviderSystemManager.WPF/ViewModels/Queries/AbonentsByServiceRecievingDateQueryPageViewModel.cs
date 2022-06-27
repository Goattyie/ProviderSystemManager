using DevExpress.Mvvm;
using ProviderSystemManager.DAL.Queries.Interfaces;
using System;
using System.Collections.ObjectModel;

namespace ProviderSystemManager.WPF.ViewModels.Queries
{
    internal class AbonentsByServiceRecievingDateQueryPageViewModel : BindableBase
    {
        private readonly IAbonentsByServiceRecievingDateQuery _query;

        public AbonentsByServiceRecievingDateQueryPageViewModel(IAbonentsByServiceRecievingDateQuery query)
        {
            _query = query;
            Date = DateTime.Now;
            Data = new();
        }

        public ObservableCollection<AbonentsByServiceRecievingDateModel> Data { get; set; }
        public DateTime Date { get; set; }

        public IAsyncCommand Execute => new AsyncCommand(async () =>
        {
            var result = await _query.Execute(Date.ToString("yyyy-MM-dd"));

            Data.Clear();

            foreach (var item in result)
            {
                Data.Add(item);
            }
        });
    }
}
