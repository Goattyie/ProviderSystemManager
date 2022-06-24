using DevExpress.Mvvm;
using ProviderSystemManager.DAL.Models.Queries;
using ProviderSystemManager.DAL.Queries.Interfaces;
using System;
using System.Collections.ObjectModel;

namespace ProviderSystemManager.WPF.ViewModels.Queries
{
    internal class FirmsByStartDateWithServicesQueryPageViewModel : BindableBase
    {
        private readonly IFirmsByStartDateWithServicesQuery _query;

        public FirmsByStartDateWithServicesQueryPageViewModel(IFirmsByStartDateWithServicesQuery query)
        {
            _query = query;
            FirstYear = DateTime.Now.Year;
            SecondYear = DateTime.Now.Year;
            Data = new();
        }

        public ObservableCollection<FirmService> Data { get; set; }
        public int FirstYear { get; set; }
        public int SecondYear { get; set; }

        public IAsyncCommand Execute => new AsyncCommand(async () =>
        {
            var result = await _query.Execute(FirstYear.ToString(), SecondYear.ToString());

            Data.Clear();

            foreach (var item in result)
            {
                Data.Add(item);
            }
        });
    }
}
