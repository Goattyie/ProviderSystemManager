using DevExpress.Mvvm;
using ProviderSystemManager.DAL.Models.Queries;
using ProviderSystemManager.DAL.Queries.Interfaces;
using System;
using System.Collections.ObjectModel;

namespace ProviderSystemManager.WPF.ViewModels.Queries
{
    internal class FirmsByServiceRecievingDateQueryPageViewModel : BindableBase
    {
        private readonly IFirmsByServiceRecievingDate _query;

        public FirmsByServiceRecievingDateQueryPageViewModel(IFirmsByServiceRecievingDate query) 
        {
            _query = query;
            Date = DateTime.Now;
            Data = new();
        }

        public ObservableCollection<FirmService> Data { get; set; }
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
