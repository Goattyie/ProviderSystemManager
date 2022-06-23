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
    internal class GetAbonentsByTypeQueryPageViewModel : BindableBase
    {
        private readonly IGetEmailsByAbonentTypeQuery _query;
        private readonly IAbonentTypeService _abonentTypeService;

        public GetAbonentsByTypeQueryPageViewModel(IAbonentTypeService abonentTypeService, IGetEmailsByAbonentTypeQuery query)
        {
            _query = query;
            _abonentTypeService = abonentTypeService;
            AbonentTypes = new(_abonentTypeService.Get().Result);
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
