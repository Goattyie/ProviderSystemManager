using DevExpress.Mvvm;
using ProviderSystemManager.DAL.Enums;
using ProviderSystemManager.WPF.Session;
using ProviderSystemManager.WPF.Views.Admin;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProviderSystemManager.WPF.ViewModels
{
    internal class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel(AdminMainPage adminPage)
        {
            switch (User.Role)
            {
                case UserRole.Admin: CurrentPage = adminPage; break;
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
