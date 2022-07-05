using DevExpress.Mvvm;
using ProviderSystemManager.WPF.Views.Tables;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProviderSystemManager.WPF.ViewModels.Roles
{
    internal class OperatorMainPageViewModel : BindableBase
    {
        private readonly ContractAbonentPage _contractPage;
        private readonly ServicePage _servicePage;

        public OperatorMainPageViewModel(ContractAbonentPage contractPage, ServicePage servicePage)
        {
            _contractPage = contractPage;
            _servicePage = servicePage;
            CurrentTablePage = _contractPage;
        }

        public Page CurrentTablePage { get; set; }

        public ICommand OnTableSelect => new DelegateCommand<string>((tableName) =>
        {
            switch (tableName.ToString())
            {
                case "contract": CurrentTablePage = _contractPage; break;
                case "service": CurrentTablePage = _servicePage; break;
            }
        });
    }
}
