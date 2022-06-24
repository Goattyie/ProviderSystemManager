using DevExpress.Mvvm;
using ProviderSystemManager.BLL.Services.Interfaces;
using ProviderSystemManager.DAL.Models.Queries;
using ProviderSystemManager.DAL.Queries.Interfaces;
using ProviderSystemManager.Shared.Dtos.Get;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ProviderSystemManager.WPF.ViewModels.Queries
{
    internal class AbonentsByAbonentTypeQueryPageViewModel : BindableBase
    {
        private readonly IAbonentsByAbonentTypeQuery _query;

        public AbonentsByAbonentTypeQueryPageViewModel(IAbonentTypeService abonentTypeService, IAbonentsByAbonentTypeQuery query)
        {
            _query = query;
            AbonentTypes = new(abonentTypeService.Get().Result);
            SelectedAbonentType = AbonentTypes.FirstOrDefault();
            Data = new ObservableCollection<EmailsByAbonentTypeModel>();
        }

        public List<AbonentTypeGetDto> AbonentTypes { get; set; }
        public AbonentTypeGetDto SelectedAbonentType { get; set; }
        public ObservableCollection<EmailsByAbonentTypeModel> Data { get; set; }

        public IAsyncCommand Execute => new AsyncCommand(async () =>
        {
            var result = await _query.Execute(SelectedAbonentType.Name);

            Data.Clear();

            foreach(var item in result)
            {
                Data.Add(item);
            }
        });
    }
}
