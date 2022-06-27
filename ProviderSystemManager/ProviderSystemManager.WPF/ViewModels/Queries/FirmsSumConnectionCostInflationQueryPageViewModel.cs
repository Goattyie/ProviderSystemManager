using DevExpress.Mvvm;
using ProviderSystemManager.DAL.Queries.Interfaces;
using System;
using System.Collections.ObjectModel;

namespace ProviderSystemManager.WPF.ViewModels.Queries
{
    internal class FirmsSumConnectionCostInflationQueryPageViewModel : BindableBase
    {
        private readonly IFirmsSumConnectionCostInflationQuery _query;

        public FirmsSumConnectionCostInflationQueryPageViewModel(IFirmsSumConnectionCostInflationQuery query)
        {
            _query = query;
            FirstDate = DateTime.Now;
            SecondDate = DateTime.Now;
            Data = new();
        }

        public DateTime FirstDate { get; set; }
        public DateTime SecondDate { get; set; }
        public ObservableCollection<FirmsSumConnectionCostInflationModel> Data { get; set; }
        public IAsyncCommand Execute => new AsyncCommand(async () =>
        {
            var result = await _query.Execute(FirstDate.ToString("yyyy-MM-dd"), SecondDate.ToString("yyyy-MM-dd"));

            Data.Clear();

            foreach (var item in result)
            {
                Data.Add(item);
            }
        });
    }
}
