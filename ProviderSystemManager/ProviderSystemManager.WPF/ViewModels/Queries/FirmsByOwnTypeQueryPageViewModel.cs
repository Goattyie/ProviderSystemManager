using DevExpress.Mvvm;
using ProviderSystemManager.BLL.Services.Interfaces;
using ProviderSystemManager.DAL.Queries.Interfaces;
using ProviderSystemManager.Shared.Dtos.Get;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ProviderSystemManager.WPF.ViewModels.Queries
{
    internal class FirmsByOwnTypeQueryPageViewModel : BindableBase
    {
        private readonly IFirmsByOwnType _query;

        public FirmsByOwnTypeQueryPageViewModel(IOwnTypeService service, IFirmsByOwnType query)
        {
            _query = query;
            OwnTypes = new(service.Get().Result);
            SelectedOwnType = OwnTypes.FirstOrDefault();
            Data = new ObservableCollection<string>();
        }

        public List<OwnTypeGetDto> OwnTypes { get; set; }
        public OwnTypeGetDto SelectedOwnType { get; set; }
        public ObservableCollection<string> Data { get; set; }

        public IAsyncCommand Execute => new AsyncCommand(async () =>
        {
            var result = await _query.Execute(SelectedOwnType.Name);

            Data.Clear();

            foreach (var item in result)
            {
                Data.Add(item);
            }
        });
    }
}
