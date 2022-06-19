using DevExpress.Mvvm;
using ProviderSystemManager.BLL.Services.Interfaces;
using ProviderSystemManager.Shared.Dtos.Get;
using System.Collections.ObjectModel;

namespace ProviderSystemManager.WPF.ViewModels.Tables
{
    internal class ServicePageViewModel : BindableBase
    {
        private readonly IServiceService _serviceService;
        private readonly IFirmService _firmService;

        public ServicePageViewModel(IServiceService serviceService, IFirmService firmService)
        {
            _serviceService = serviceService;
            _firmService = firmService;

            Services = new(_serviceService.Get().Result);
            Firms = new(_firmService.Get().Result);
        }

        public ObservableCollection<ServiceGetDto> Services { get; set; }
        public ObservableCollection<FirmGetDto> Firms { get; set; }
        public ServiceGetDto SelectedService { get; set; }
        public FirmGetDto SelectedFirm { get; set; }
    }
}
