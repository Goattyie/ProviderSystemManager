using DevExpress.Mvvm;
using ProviderSystemManager.DAL.Enums;
using ProviderSystemManager.WPF.Session;
using ProviderSystemManager.WPF.Views.Admin;
using ProviderSystemManager.WPF.Views.Roles;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProviderSystemManager.WPF.ViewModels
{
    internal class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel(AdminMainPage adminPage, OperatorMainPage operatorPage, UserMainPage userPage)
        {
            switch (User.Role)
            {
                case UserRole.Admin: CurrentPage = adminPage; break;
                case UserRole.Operator: CurrentPage = operatorPage; break;
                case UserRole.User: CurrentPage = userPage; break;
            }
        }

        public Action OnExitAction { get; set; }
        public Page CurrentPage { get; set; }

        public ICommand OnExit => new DelegateCommand(() =>
        {
            OnExitAction?.Invoke();
        });
    }
}
