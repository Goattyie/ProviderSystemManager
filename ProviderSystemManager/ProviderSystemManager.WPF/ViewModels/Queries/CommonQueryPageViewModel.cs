using DevExpress.Mvvm;
using ProviderSystemManager.WPF.Views.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace ProviderSystemManager.WPF.ViewModels.Queries
{
    internal class CommonQueryPageViewModel : BindableBase
    {
        private readonly List<Page> _queryPages;

        public CommonQueryPageViewModel(GetAbonentsByTypeQueryPage getAbonentsByTypeQueryPage, 
            FirmNamesByOwnTypeQueryPage firmNamesByOwnTypeQueryPage, 
            FirmServiceSizeByDateQueryPage firmServiceSizeByDateQueryPage,
            ContractsInfoQueryPage contractsInfoQueryPage,
            ServiceInfoQueryPage serviceInfoQueryPage,
            ContractAbonentsEmailNotNullQueryPage contractAbonentsEmailNotNullQueryPage,
            FirmHaveServicesQueryPage firmHaveServicesQueryPage,
            FirmsByStartDateWithServicesQueryPage firmsByServiceRecievingDateQueryPage)
        {
            _queryPages = new()
            {
                getAbonentsByTypeQueryPage,
                firmNamesByOwnTypeQueryPage,
                firmServiceSizeByDateQueryPage,
                contractsInfoQueryPage,
                serviceInfoQueryPage,
                contractAbonentsEmailNotNullQueryPage,
                firmHaveServicesQueryPage,
                firmsByServiceRecievingDateQueryPage
            };
            CurrentPage = _queryPages.FirstOrDefault();
            QueryTitles = new()
            {
                "Получить абонентов с указанным типом",
                "Получить фирмы с заданным типом собственности",
                "Вывести все фирмы, которые предоставляли услуги в указанную дату",
                "Вывести абонентов и стоимость подключения их контрактов",
                "Вывести абонентов и объем сообщения их услуг",
                "Вывести все контракты абонентов, у которых указана почта",
                "Вывести все фирмы, которые хоть раз отказывали услуги",
                "Вывести все фирмы, которые хоть раз отказывали услуги и были открыты в указанный перидо"
            };
            SelectedTitle = QueryTitles.FirstOrDefault();
        }

        public Page CurrentPage { get; set; }
        public List<string> QueryTitles { get; set; }
        public string SelectedTitle { 
            get => GetValue<string>(nameof(SelectedTitle)); 
            set 
            {
                var selectedIndex = QueryTitles.IndexOf(value);
                CurrentPage = _queryPages[selectedIndex];
                SetValue(value, nameof(SelectedTitle));
            }
        }
    }
}
