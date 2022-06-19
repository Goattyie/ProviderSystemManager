using DevExpress.Mvvm;
using ProviderSystemManager.BLL.Services.Interfaces;
using ProviderSystemManager.Shared.Dtos.Get;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;

namespace ProviderSystemManager.WPF.ViewModels.Tables
{
    internal class AbonentPageViewModel : BindableBase
    {
        private readonly IAbonentService _abonentService;
        private readonly IAbonentTypeService _abonentTypeService;

        public AbonentPageViewModel(IAbonentService abonentService, IAbonentTypeService abonentTypeService)
        {
            _abonentService = abonentService;
            _abonentTypeService = abonentTypeService;

            Abonents = new(_abonentService.Get().Result);
            AbonentTypes = new(_abonentTypeService.Get().Result);
        }

        public ObservableCollection<AbonentGetDto> Abonents { get; set; }
        public ObservableCollection<AbonentTypeGetDto> AbonentTypes { get; set; }
        public AbonentGetDto SelectedAbonent { get; set; }
    }
}
