using DevExpress.Mvvm;
using ProviderSystemManager.BLL.Services;
using ProviderSystemManager.BLL.Services.Interfaces;
using ProviderSystemManager.Shared.Dtos.Create;
using ProviderSystemManager.Shared.Dtos.Get;
using ProviderSystemManager.WPF.Localization;
using ProviderSystemManager.WPF.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProviderSystemManager.WPF.ViewModels.Tables.CreateUpdate.Create
{
    internal class FirmCreateWindowViewModel : BindableBase
    {
        private readonly IFirmService _service;

        public FirmCreateWindowViewModel(IOwnTypeService ownTypeService, IFirmService firmService)
        {
            _service = firmService;
            CreateDto = new();
            OwnTypes = new(ownTypeService.Get().Result);
            SelectedOwnType = OwnTypes.FirstOrDefault();
        }

        public FirmCreateDto CreateDto { get; set; }
        public List<OwnTypeGetDto> OwnTypes { get; set; }
        public OwnTypeGetDto SelectedOwnType 
        {
            get => GetValue<OwnTypeGetDto>(nameof(SelectedOwnType));
            set
            {
                CreateDto.OwnTypeId = value.Id;

                SetValue(value, nameof(SelectedOwnType));
            }
        }
        public IAsyncCommand CreateCommand => new AsyncCommand(async () =>
        {
            try
            {
                var createResult = await _service.CreateAsync(CreateDto);

                if (createResult.CodeResult == Shared.CodeResult.Bad)
                {
                    MessageBoxManager.ShowError(createResult.Errors.First());
                    return;
                }

                MessageBoxManager.ShowSuccess(Phrases.CreateFirmSuccess);
            }
            catch(Exception ex){ MessageBoxManager.ShowError(ex.InnerException.Message); }
        });
    }
}
