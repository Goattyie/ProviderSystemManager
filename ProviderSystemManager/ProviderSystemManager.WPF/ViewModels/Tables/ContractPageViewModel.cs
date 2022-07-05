using DevExpress.Mvvm;
using ProviderSystemManager.BLL.Services.Interfaces;
using ProviderSystemManager.Shared.Dtos.Get;
using ProviderSystemManager.WPF.Views.Tables.CreateUpdate.Create;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ProviderSystemManager.WPF.ViewModels.Tables
{
    public class ContractPageViewModel : BindableBase
    {
        private readonly IContractService _contractService;
        private readonly IFirmService _firmService;

        public ContractPageViewModel(IContractService contractService, IFirmService firmService)
        {
            _contractService = contractService;
            _firmService = firmService;

            Contracts = new(_contractService.Get().Result);
            Firms = new(_firmService.Get().Result);
        }

        public ObservableCollection<ContractGetDto> Contracts { get; set; }
        public ObservableCollection<FirmGetDto> Firms { get; set; }
        public FirmGetDto SelectedFirm 
        { 
            get => GetValue<FirmGetDto>(nameof(SelectedFirm));
            set 
            {
                SetValue(value, nameof(SelectedFirm));

                var contractsRequest = _contractService.GetByFirmId(value.Id);

                Contracts.Clear();

                if (contractsRequest.CodeResult is not Shared.CodeResult.Ok)
                    return;

                foreach(var contract in contractsRequest.Result)
                {
                    Contracts.Add(contract);
                }
            } 
        }
        public ContractGetDto SelectedContract { get; set; }
        public ICommand CreateCommand => new DelegateCommand(() => 
        {
            new ContractCreateWindow().Show();
        });
    }
}
