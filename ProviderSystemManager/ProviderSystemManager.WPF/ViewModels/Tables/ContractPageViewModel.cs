using DevExpress.Mvvm;
using ProviderSystemManager.BLL.Services.Interfaces;
using ProviderSystemManager.Shared.Dtos.Get;
using System.Collections.ObjectModel;

namespace ProviderSystemManager.WPF.ViewModels.Tables
{
    public class ContractPageViewModel : BindableBase
    {
        private readonly IContractService _contractService;
        private readonly IAbonentService _abonentService;

        public ContractPageViewModel(IContractService contractService, IAbonentService abonentService)
        {
            _contractService = contractService;
            _abonentService = abonentService;

            Contracts = new(_contractService.Get().Result);
            Abonents = new(_abonentService.Get().Result);
        }

        public ObservableCollection<ContractGetDto> Contracts { get; set; }
        public ObservableCollection<AbonentGetDto> Abonents { get; set; }
        public ContractGetDto SelectedContract { get; set; }
    }
}
