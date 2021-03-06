using DevExpress.Mvvm;
using ProviderSystemManager.BLL.Services.Interfaces;
using ProviderSystemManager.Shared.Dtos.Get;
using System.Collections.ObjectModel;

namespace ProviderSystemManager.WPF.ViewModels.Tables
{
    internal class ServicePageViewModel : BindableBase
    {
        private readonly IServiceService _serviceService;
        private readonly IAbonentService _abonentService;

        public ServicePageViewModel(IServiceService serviceService, IAbonentService abonentService)
        {
            _serviceService = serviceService;
            _abonentService = abonentService;

            Services = new(_serviceService.Get().Result);
            Abonents = new(_abonentService.Get().Result);
        }

        public ObservableCollection<ServiceGetDto> Services { get; set; }
        public ObservableCollection<AbonentGetDto> Abonents { get; set; }
        public ServiceGetDto SelectedService { get; set; }
        public AbonentGetDto SelectedAbonent { get; set; }
    }
}
