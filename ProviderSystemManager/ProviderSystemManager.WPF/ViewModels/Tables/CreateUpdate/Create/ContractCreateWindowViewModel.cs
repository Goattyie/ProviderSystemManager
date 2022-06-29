using DevExpress.Mvvm;
using ProviderSystemManager.BLL.Services.Interfaces;
using ProviderSystemManager.Shared.Dtos.Create;
using ProviderSystemManager.Shared.Dtos.Get;
using System;
using System.Collections.Generic;

namespace ProviderSystemManager.WPF.ViewModels.Tables.CreateUpdate.Create
{
    internal class ContractCreateWindowViewModel : BindableBase
    {
        private readonly IAbonentService _abonentService;
        private readonly IFirmService _firmService;
        private readonly IContractService _service;

        public ContractCreateWindowViewModel(IAbonentService abonentService, IFirmService firmService, IContractService service)
        {
            _abonentService = abonentService;
            _firmService = firmService;
            _service = service;
            CreateDto = new() { ConnectionDate = DateTime.Now.ToString("dd.MM.yy") };
            Abonents = new(_abonentService.Get().Result);
            Firms = new(_firmService.Get().Result);
        }

        public DateTime ConnectionDate
        {
            get => GetValue<string>(nameof(ConnectionDate));
            set
            {
                CreateDto.ConnectionDate = value.ToString("dd.MM.yy");
                SetValue(nameof(ConnectionDate));
            }
        }
        public ContractCreateDto CreateDto { get; set; }
        public List<AbonentGetDto> Abonents { get; set; }
        public List<FirmGetDto> Firms { get; set; }
        public IAsyncCommand ExecuteCommand => new AsyncCommand(async () =>
        {
            var result = await _service.CreateAsync(CreateDto);
        });
    }
}
