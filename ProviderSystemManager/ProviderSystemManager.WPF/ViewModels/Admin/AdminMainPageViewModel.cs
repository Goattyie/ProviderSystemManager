using DevExpress.Mvvm;
using ProviderSystemManager.WPF.Views.Tables;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProviderSystemManager.WPF.ViewModels.Admin
{
    internal class AdminMainPageViewModel : BindableBase
    {
        private readonly UsersPage _usersPage;

        public AdminMainPageViewModel(UsersPage usersPage)
        {
            _usersPage = usersPage;
            CurrentTablePage = _usersPage;
        }

        public Page CurrentTablePage { get; set; }
        public Page OperatorsPage { get; set; }

        public ICommand OnTableSelect => new DelegateCommand<string>((tableName) =>
        {
            switch (tableName)
            {
                case "users": CurrentTablePage = _usersPage; break;
            }
        });
    }
}
