using DevExpress.Mvvm;
using ProviderSystemManager.WPF.Views.Queries;
using ProviderSystemManager.WPF.Views.Tables;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProviderSystemManager.WPF.ViewModels.Roles
{
    internal class AdminMainPageViewModel : BindableBase
    {
        private readonly UsersPage _usersPage;
        private readonly CommonQueryPage _queryPage;

        public AdminMainPageViewModel(UsersPage usersPage, CommonQueryPage queryPage)
        {
            _usersPage = usersPage;
            _queryPage = queryPage;
            CurrentTablePage = _usersPage;
        }

        public Page CurrentTablePage { get; set; }
        public Page OperatorsPage { get; set; }

        public ICommand OnTableSelect => new DelegateCommand<string>((tableName) =>
        {
            switch (tableName)
            {
                case "users": CurrentTablePage = _usersPage; break;
                case "queries": CurrentTablePage = _queryPage; break;
            }
        });
    }
}
