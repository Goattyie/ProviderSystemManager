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
            FirmsByStartDateWithServicesQueryPage firmsByServiceRecievingDateQueryPage,
            AbonentsByServiceRecievingDateQueryPage abonentsByServiceRecievingDateQueryPage,
            AbonentInfoQueryPage abonentInfoQueryPage,
            SumSizeFirmsQueryPage sumSizeFirmsQueryPage,
            FirmsCountByOwnTypeQueryPage firmsCountByOwnTypeQueryPage,
            AbonentsByContractsSumQueryPage abonentsByContractsSumQueryPage,
            AbonentsByContractsSumAndDateQueryPage abonentsByContractsSumAndDateQueryPage,
            FirmsSumConnectionCostInflationQueryPage firmsSumConnectionCostInflationQueryPage,
            FirmsSumConnectionCostMoreAvgQueryPage firmsSumConnectionCostMoreAvgQueryPage,
            MaskQueryPage maskQueryPage,
            CaseQueryPage caseQueryPage,
            UnionQueryPage unionQueryPage,
            InQueryPage inQueryPage,
            NotInQueryPage notInQueryPage)
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
                firmsByServiceRecievingDateQueryPage,
                abonentsByServiceRecievingDateQueryPage,
                abonentInfoQueryPage,
                sumSizeFirmsQueryPage,
                firmsCountByOwnTypeQueryPage,
                abonentsByContractsSumQueryPage,
                abonentsByContractsSumAndDateQueryPage,
                firmsSumConnectionCostInflationQueryPage,
                firmsSumConnectionCostMoreAvgQueryPage,
                maskQueryPage,
                caseQueryPage,
                unionQueryPage,
                inQueryPage,
                notInQueryPage
            };
            CurrentPage = _queryPages.FirstOrDefault();
            QueryTitles = new()
            {
                "Вывести абонентов с указанным типом",
                "Вывести фирмы с заданным типом собственности",
                "Вывести все фирмы, которые предоставляли услуги в указанную дату",
                "Вывести абонентов и стоимость подключения их контрактов",
                "Вывести абонентов и объем сообщения их услуг",
                "Вывести все контракты абонентов, у которых указана почта",
                "Вывести все фирмы, которые хоть раз отказывали услуги",
                "Вывести все фирмы, которые хоть раз отказывали услуги и были открыты в указанный период",
                "Вывести всех абонентов и объем сообщения услуг, предоставленных в указанную дату",
                "Вывести имена абонентов и их тип",
                "Вывести фирмы и их общее число предоставленных МБ",
                "Вывести количество фирм с указанным типом собственности",
                "Вывести абонентов, которые составили контрактов на подключение в сумме на цену более указанного числа",
                "Вывести абонентов, которые составили контрактов на подключение в сумме на цену более указанного числа и которые начинаются в указанную дату",
                "Вывести фирмы и их общую прибыль за подключение до и после инфляции (уменьшение на 30%), в период за между двумя датами",
                "Вывести фирмы и их общую прибыль за подключения, сумма которой больше средней прибыли за подключения",
                "Вывести типы собственности и количество компаний, в названии которых встречается введенная подстрока",
                "Вывести среднюю стоимость подключения указанной фирмы",
                "Вывести количество контрактов и предоставляемых услуг",
                "Вывести все контракты, фирмы которых имеют указанный тип собственности",
                "Вывести все контракты, фирмы которых не имеют указанный тип собственности"
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
