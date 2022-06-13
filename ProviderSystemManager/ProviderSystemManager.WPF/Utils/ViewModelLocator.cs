using ProviderSystemManager.WPF.DI;
using ProviderSystemManager.WPF.ViewModels;
using ProviderSystemManager.WPF.ViewModels.Admin;
using ProviderSystemManager.WPF.ViewModels.Tables;
using ProviderSystemManager.WPF.ViewModels.Tables.CreateUpdate;
using ProviderSystemManager.WPF.Views.Admin;

namespace ProviderSystemManager.WPF.Utils
{
    internal class ViewModelLocator
    {
        public SignInWindowViewModel SignInWindowViewModel => IoC.Resolve<SignInWindowViewModel>();
        public MainWindowViewModel MainWindowViewModel => IoC.Resolve<MainWindowViewModel>();
        public AdminMainPageViewModel AdminMainPageViewModel => IoC.Resolve<AdminMainPageViewModel>();
        public UsersPageViewModel UsersPageViewModel => IoC.Resolve<UsersPageViewModel>();
        public UserCreateUpdateWindowViewModel UserCreateUpdateWindowViewModel => IoC.Resolve<UserCreateUpdateWindowViewModel>();
    }
}
