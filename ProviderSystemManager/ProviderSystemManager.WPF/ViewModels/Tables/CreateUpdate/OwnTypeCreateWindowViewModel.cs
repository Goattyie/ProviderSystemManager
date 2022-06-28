using DevExpress.Mvvm;
using ProviderSystemManager.BLL.Services.Interfaces;
using ProviderSystemManager.Shared.Dtos.Create;
using ProviderSystemManager.Shared.Dtos.Get;
using ProviderSystemManager.WPF.Localization;
using ProviderSystemManager.WPF.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProviderSystemManager.WPF.ViewModels.Tables.CreateUpdate
{
    internal class OwnTypeCreateWindowViewModel : BindableBase
    {
        private readonly IOwnTypeService _service;

        public event Action<OwnTypeGetDto> OnCreate;

        public OwnTypeCreateWindowViewModel(IOwnTypeService service)
        {
            _service = service;
            CreateDto = new();
        }
        public OwnTypeCreateDto CreateDto { get; set; }

        public ICommand CreateCommand => new AsyncCommand(async () =>
        {
            var result = await _service.CreateAsync(CreateDto);

            if (result.CodeResult == Shared.CodeResult.Ok)
            {
                MessageBoxManager.ShowSuccess(Phrases.CreateOwnTypeSuccess);
                OnCreate?.Invoke(result.Result);
            }
            else MessageBoxManager.ShowError(result.Errors.First());
        });
    }
}
