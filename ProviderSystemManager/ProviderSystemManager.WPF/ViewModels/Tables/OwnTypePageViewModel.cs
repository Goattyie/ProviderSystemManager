using DevExpress.Mvvm;
using ProviderSystemManager.BLL.Services;
using ProviderSystemManager.BLL.Services.Interfaces;
using ProviderSystemManager.Shared.Dtos.Get;
using ProviderSystemManager.WPF.Views.Tables.CreateUpdate;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ProviderSystemManager.WPF.ViewModels.Tables
{
    internal class OwnTypePageViewModel : BindableBase
    {
        private readonly IOwnTypeService _service;
        private readonly OwnTypeCreateWindow _createWindow;

        public OwnTypePageViewModel(IOwnTypeService service, OwnTypeCreateWindow createWindow)
        {
            _service = service;
            _createWindow = createWindow;
            Data = new(service.Get().Result);

            OwnTypeService.OnCreate += (array) => { foreach (var obj in array) Data.Add(obj); };
        }

        public ObservableCollection<OwnTypeGetDto> Data { get; set; }
        public OwnTypeGetDto SelectedItem { get; set; }
        public ICommand OnCreate => new DelegateCommand(() =>
        {
            _createWindow.Show();
        });

        public ICommand OnDelete => new AsyncCommand(async () =>
        {
            while (SelectedItem is not null)
            {
                var result = await _service.RemoveAsync(SelectedItem.Id);

                if (result.CodeResult == Shared.CodeResult.Ok)
                    Data.Remove(SelectedItem);
            }
        });
    }
}
