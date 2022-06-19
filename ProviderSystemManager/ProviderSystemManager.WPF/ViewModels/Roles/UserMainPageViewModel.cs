using DevExpress.Mvvm;
using ProviderSystemManager.WPF.Views.Tables;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProviderSystemManager.WPF.ViewModels.Roles
{
    internal class UserMainPageViewModel : BindableBase
    {

        private readonly AbonentPage _abonentPage;
        private readonly ContractPage _contractPage;
        private readonly ServicePage _servicePage;

        public UserMainPageViewModel(AbonentPage abonentPage, ContractPage contractPage, ServicePage servicePage)
        {
            _abonentPage = abonentPage;
            _contractPage = contractPage;
            _servicePage = servicePage;
            CurrentTablePage = contractPage;
        }

        public Page CurrentTablePage { get; set; }

        public ICommand OnTableSelect => new DelegateCommand<string>((tableName) =>
        {
            switch (tableName.ToString())
            {
                case "abonent": CurrentTablePage = _abonentPage; break;
                case "contract": CurrentTablePage = _contractPage; break;
                case "service": CurrentTablePage = _servicePage; break;
            }
        });
    }
}
