using DevExpress.Mvvm;
using ProviderSystemManager.WPF.Views.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace ProviderSystemManager.WPF.ViewModels.Queries
{
    internal class CommonQueryPageViewModel : BindableBase
    {
        private readonly GetAbonentsByTypeQueryPage _getAbonentsByTypeQueryPage;

        public CommonQueryPageViewModel(GetAbonentsByTypeQueryPage getAbonentsByTypeQueryPage)
        {
            _getAbonentsByTypeQueryPage = getAbonentsByTypeQueryPage;
            CurrentPage = _getAbonentsByTypeQueryPage;
            QueryTitles = new()
            {
                "Получить абонентов с указанным типом"
            };
            SelectedTitle = QueryTitles.FirstOrDefault();
        }

        public Page CurrentPage { get; set; }
        public List<string> QueryTitles { get; set; }
        public string SelectedTitle { get; set; }
    }
}
