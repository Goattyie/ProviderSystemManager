using DevExpress.Mvvm;
using ProviderSystemManager.BLL.Services.Interfaces;
using ProviderSystemManager.DAL.Queries.Interfaces;
using ProviderSystemManager.Shared.Dtos.Get;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ProviderSystemManager.WPF.ViewModels.Queries
{
    internal class FirmsCountByOwnTypeQueryPageViewModel : BindableBase
    {
        private readonly IFirmsCountByOwnTypeQuery _query;

        public FirmsCountByOwnTypeQueryPageViewModel(IOwnTypeService service, IFirmsCountByOwnTypeQuery query)
        {
            _query = query;
            Data = new();
            OwnTypes = new(service.Get().Result);
            SelectedOwnType = OwnTypes.FirstOrDefault();
        }


        public ObservableCollection<int> Data { get; set; }
        public List<OwnTypeGetDto> OwnTypes { get; set; }
        public OwnTypeGetDto SelectedOwnType { get; set; }
        public IAsyncCommand Execute => new AsyncCommand(async () =>
        {
            Data.Clear();
            Data.Add(await _query.Execute(SelectedOwnType.Name));
        });
    }
}
