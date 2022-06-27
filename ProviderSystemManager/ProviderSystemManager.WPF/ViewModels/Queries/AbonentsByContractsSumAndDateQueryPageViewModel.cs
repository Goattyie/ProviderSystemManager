using DevExpress.Mvvm;
using ProviderSystemManager.DAL.Queries.Interfaces;
using System;
using System.Collections.ObjectModel;

namespace ProviderSystemManager.WPF.ViewModels.Queries
{
    internal class AbonentsByContractsSumAndDateQueryPageViewModel : BindableBase
    {
        private readonly IAbonentsByContractsSumAndDateQuery _query;

        public AbonentsByContractsSumAndDateQueryPageViewModel(IAbonentsByContractsSumAndDateQuery query)
        {
            _query = query; 
            Data = new();
            Date = DateTime.Now;
        }

        public ObservableCollection<AbonentByContractsSumModel> Data { get; set; }
        public int? Count { get; set; }
        public DateTime Date { get; set; }

        public IAsyncCommand Execute => new AsyncCommand(async () =>
        {
            var result = await _query.Execute(Count?.ToString(), Date.ToString("yyyy-MM-dd"));

            Data.Clear();

            foreach (var item in result)
            {
                Data.Add(item);
            }
        });
    }
}
