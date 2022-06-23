using ProviderSystemManager.WPF.DI;
using ProviderSystemManager.WPF.ViewModels;
using ProviderSystemManager.WPF.ViewModels.Queries;
using ProviderSystemManager.WPF.ViewModels.Roles;
using ProviderSystemManager.WPF.ViewModels.Tables;
using ProviderSystemManager.WPF.ViewModels.Tables.CreateUpdate;

namespace ProviderSystemManager.WPF.Utils
{
    internal class ViewModelLocator
    {
        public SignInWindowViewModel SignInWindowViewModel => IoC.Resolve<SignInWindowViewModel>();
        public MainWindowViewModel MainWindowViewModel => IoC.Resolve<MainWindowViewModel>();
        public AdminMainPageViewModel AdminMainPageViewModel => IoC.Resolve<AdminMainPageViewModel>();
        public OperatorMainPageViewModel OperatorMainPageViewModel => IoC.Resolve<OperatorMainPageViewModel>();
        public UserMainPageViewModel UserMainPageViewModel => IoC.Resolve<UserMainPageViewModel>();
        public UsersPageViewModel UsersPageViewModel => IoC.Resolve<UsersPageViewModel>();
        public UserCreateUpdateWindowViewModel UserCreateUpdateWindowViewModel => IoC.Resolve<UserCreateUpdateWindowViewModel>();
        public FirmPageViewModel FirmPageViewModel => IoC.Resolve<FirmPageViewModel>();
        public AbonentPageViewModel AbonentPageViewModel => IoC.Resolve<AbonentPageViewModel>();
        public ContractPageViewModel ContractPageViewModel => IoC.Resolve<ContractPageViewModel>();
        public ServicePageViewModel ServicePageViewModel => IoC.Resolve<ServicePageViewModel>();
        public CommonQueryPageViewModel CommonQueryPageViewModel => IoC.Resolve<CommonQueryPageViewModel>();
        public GetAbonentsByTypeQueryPageViewModel GetAbonentsByTypeQueryPageViewModel => IoC.Resolve<GetAbonentsByTypeQueryPageViewModel>();
    }
}
