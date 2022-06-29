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
        public AbonentGetDto SelectedAbonent 
        { 
            get => GetValue<AbonentGetDto>(nameof(SelectedAbonent));
            set 
            {
                SetValue(value, nameof(SelectedAbonent));

                var contractsRequest = _contractService.GetByAbonentId(value.Id);

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
