using DevExpress.Mvvm;
using Microsoft.EntityFrameworkCore;
using ProviderSystemManager.BLL.Services;
using ProviderSystemManager.BLL.Services.Interfaces;
using ProviderSystemManager.Shared.Dtos.Get;
using ProviderSystemManager.WPF.Utils;
using ProviderSystemManager.WPF.Views.Tables.CreateUpdate.Create;
using ProviderSystemManager.WPF.Views.Tables.CreateUpdate.Update;
using System.Collections.ObjectModel;
using System.Linq;

namespace ProviderSystemManager.WPF.ViewModels.Tables
{
    internal class FirmPageViewModel : BindableBase
    {
        private readonly IFirmService _firmService;
        private readonly IOwnTypeService _ownTypeService;

        public FirmPageViewModel(IFirmService firmService, IOwnTypeService ownTypeService)
        {
            _firmService = firmService;
            _ownTypeService = ownTypeService;

            Firms = new(_firmService.Get().Result);
            OwnTypes = new(_ownTypeService.Get().Result);

            FirmService.OnCreate += (array) =>
            {
                foreach (var obj in array)
                {
                    Firms.Add(obj);
                }
            };

            FirmService.OnUpdate += () =>
            {
                Firms.Clear();

                var array = _firmService.Get().Result;

                foreach (var obj in array)
                {
                    Firms.Add(obj);
                }
            };
        }

        public ObservableCollection<FirmGetDto> Firms{ get; set; }
        public ObservableCollection<OwnTypeGetDto> OwnTypes { get; set; }
        public FirmGetDto SelectedFirm { get; set; }

        public IDelegateCommand OnCreate => new DelegateCommand(() =>
        {
            new FirmCreateWindow().Show();
        });

        public IDelegateCommand OnUpdate => new DelegateCommand(() =>
        {
            new FirmUpdateWindow(SelectedFirm).Show();
        });

        public IAsyncCommand OnDelete => new AsyncCommand(async () =>
        {
            if (SelectedFirm is null)
                return;

            try
            {
                var result = await _firmService.RemoveAsync(SelectedFirm.Id);

                if (result.CodeResult == Shared.CodeResult.Bad)
                {
                    MessageBoxManager.ShowError(result.Errors.First());
                    return;
                }

                Firms.Remove(SelectedFirm);
            }catch(DbUpdateException ex) { MessageBoxManager.ShowError("У данной фирмы еще есть контракты с пользователями"); }
        });
    }
}
