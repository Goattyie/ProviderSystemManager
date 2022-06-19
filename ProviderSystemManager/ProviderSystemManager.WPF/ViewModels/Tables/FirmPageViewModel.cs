using DevExpress.Mvvm;
using ProviderSystemManager.BLL.Services.Interfaces;
using ProviderSystemManager.Shared.Dtos.Get;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;

namespace ProviderSystemManager.WPF.ViewModels.Tables
{
    internal class FirmPageViewModel : BindableBase
    {
        private readonly IFirmService _firmService;
        private readonly IOwnTypeService _ownTypeService;

        public FirmPageViewModel(IFirmService firmService, IOwnTypeService ownTypeService)
        {
            _firmService = firmService;
            _ownTypeService = ownTypeService;

            Firms = new(_firmService.Get().Result);
            OwnTypes = new(_ownTypeService.Get().Result);
        }

        public ObservableCollection<FirmGetDto> Firms{ get; set; }
        public ObservableCollection<OwnTypeGetDto> OwnTypes { get; set; }
        public FirmGetDto SelectedFirm { get; set; }
    }
}
