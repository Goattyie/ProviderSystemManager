using DevExpress.Mvvm;
using ProviderSystemManager.WPF.Views.Roles.User;
using ProviderSystemManager.WPF.Views.Tables;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProviderSystemManager.WPF.ViewModels.Roles
{
    internal class UserMainPageViewModel : BindableBase
    {

        private readonly ContractPage _contractPage;
        private readonly UserAboutPage _userAboutPage;

        public UserMainPageViewModel(ContractPage contractPage, UserAboutPage userAboutPage)
        {
            _contractPage = contractPage;
            _userAboutPage = userAboutPage;
            CurrentTablePage = _contractPage;
        }

        public Page CurrentTablePage { get; set; }

        public ICommand OnTableSelect => new DelegateCommand<string>((tableName) =>
        {
            switch (tableName.ToString())
            {
                case "contract": CurrentTablePage = _contractPage; break;
                case "about": CurrentTablePage = _userAboutPage; break;
            }
        });
    }
}
