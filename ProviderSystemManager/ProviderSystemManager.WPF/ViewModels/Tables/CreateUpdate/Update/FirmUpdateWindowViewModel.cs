using DevExpress.Mvvm;
using ProviderSystemManager.BLL.Services.Interfaces;
using ProviderSystemManager.Shared.Dtos.Get;
using ProviderSystemManager.Shared.Dtos.Update;
using ProviderSystemManager.WPF.Localization;
using ProviderSystemManager.WPF.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProviderSystemManager.WPF.ViewModels.Tables.CreateUpdate.Update
{
    internal class FirmUpdateWindowViewModel : BindableBase
    {
        private readonly IFirmService _service;

        public FirmUpdateWindowViewModel(IOwnTypeService ownTypeService, IFirmService firmService)
        {
            _service = firmService;
            Dto = new();
            OwnTypes = new(ownTypeService.Get().Result);
            SelectedOwnType = OwnTypes.FirstOrDefault();
        }

        public FirmGetDto Dto { get; set; }
        public List<OwnTypeGetDto> OwnTypes { get; set; }
        public OwnTypeGetDto SelectedOwnType
        {
            get => GetValue<OwnTypeGetDto>(nameof(SelectedOwnType));
            set
            {
                if(Dto.OwnType is not null)
                    Dto.OwnType.Id = value.Id;

                SetValue(value, nameof(SelectedOwnType));
            }
        }
        public IAsyncCommand UpdateCommand => new AsyncCommand(async () =>
        {
            try
            {
                var updateDto = new FirmUpdateDto
                {
                    Id = Dto.Id,
                    Name = Dto.Name,
                    Address = Dto.Address,
                    Telephone = Dto.Telephone,
                    OwnTypeId = SelectedOwnType.Id
                };

                var createResult = await _service.UpdateAsync(updateDto);

                if (createResult.CodeResult == Shared.CodeResult.Bad)
                {
                    MessageBoxManager.ShowError(createResult.Errors.First());
                    return;
                }

                MessageBoxManager.ShowSuccess(Phrases.UpdateFirmSuccess);
            }
            catch (Exception ex) { MessageBoxManager.ShowError(ex.InnerException.Message); }
        });
    }
}
