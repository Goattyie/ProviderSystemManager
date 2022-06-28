using DevExpress.Mvvm;
using ProviderSystemManager.BLL.Services.Interfaces;
using ProviderSystemManager.Shared.Dtos.Create;
using ProviderSystemManager.Shared.Dtos.Get;
using ProviderSystemManager.WPF.Localization;
using ProviderSystemManager.WPF.Utils;
using System;
using System.Linq;
using System.Windows.Input;

namespace ProviderSystemManager.WPF.ViewModels.Tables.CreateUpdate
{
    internal class AbonentTypeCreateWindowViewModel : BindableBase
    {
        private readonly IAbonentTypeService _service;

        public event Action<AbonentTypeGetDto> OnCreate;

        public AbonentTypeCreateWindowViewModel(IAbonentTypeService service)
        {
            _service = service;
            CreateDto = new();
        }
        public AbonentTypeCreateDto CreateDto { get; set; }

        public ICommand CreateCommand => new AsyncCommand(async () => 
        {
            var result = await _service.CreateAsync(CreateDto);

            if (result.CodeResult == Shared.CodeResult.Ok)
            {
                MessageBoxManager.ShowSuccess(Phrases.CreateAbonentTypeSuccess);
                OnCreate?.Invoke(result.Result);
            }
            else MessageBoxManager.ShowError(result.Errors.First());
        });
    }
}
