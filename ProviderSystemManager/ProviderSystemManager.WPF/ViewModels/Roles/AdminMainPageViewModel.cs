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
        private readonly AbonentTypesPage _abonentTypesPage;

        public AdminMainPageViewModel(UsersPage usersPage, CommonQueryPage queryPage, AbonentTypesPage abonentTypesPage, OwnTypePage ownTypePage)
        {
            _usersPage = usersPage;
            _queryPage = queryPage;
            _abonentTypesPage = abonentTypesPage;
            _ownTypePage = ownTypePage;
            CurrentTablePage = _usersPage;
        }

        private readonly OwnTypePage _ownTypePage;

        public Page CurrentTablePage { get; set; }
        public Page OperatorsPage { get; set; }

        public ICommand OnTableSelect => new DelegateCommand<string>((tableName) =>
        {
            switch (tableName)
            {
                case "users": CurrentTablePage = _usersPage; break;
                case "queries": CurrentTablePage = _queryPage; break;
                case "abonent types": CurrentTablePage = _abonentTypesPage; break;
                case "own types": CurrentTablePage = _ownTypePage; break;
            }
        });
    }
}
