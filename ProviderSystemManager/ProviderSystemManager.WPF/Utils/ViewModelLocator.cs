using ProviderSystemManager.WPF.DI;
using ProviderSystemManager.WPF.ViewModels;
using ProviderSystemManager.WPF.ViewModels.Queries;
using ProviderSystemManager.WPF.ViewModels.Roles;
using ProviderSystemManager.WPF.ViewModels.Roles.User;
using ProviderSystemManager.WPF.ViewModels.Tables;
using ProviderSystemManager.WPF.ViewModels.Tables.CreateUpdate;
using ProviderSystemManager.WPF.ViewModels.Tables.CreateUpdate.Create;
using ProviderSystemManager.WPF.ViewModels.Tables.CreateUpdate.Update;

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
        public AbonentsByAbonentTypeQueryPageViewModel GetAbonentsByTypeQueryPageViewModel => IoC.Resolve<AbonentsByAbonentTypeQueryPageViewModel>();
        public FirmsByOwnTypeQueryPageViewModel FirmNamesByOwnTypeQueryPageViewModel => IoC.Resolve<FirmsByOwnTypeQueryPageViewModel>();
        public FirmsByServiceRecievingDateQueryPageViewModel FirmServiceSizeByDateQueryPageViewModel => IoC.Resolve<FirmsByServiceRecievingDateQueryPageViewModel>();
        public ContractsInfoQueryPageViewModel ContractsInfoQueryPageViewModel => IoC.Resolve<ContractsInfoQueryPageViewModel>();
        public ServiceInfoQueryPageViewModel ServiceInfoQueryPageViewModel => IoC.Resolve<ServiceInfoQueryPageViewModel>();
        public ContractAbonentsEmailNotNullQueryPageViewModel ContractAbonentsEmailNotNullQueryPageViewModel => IoC.Resolve<ContractAbonentsEmailNotNullQueryPageViewModel>();
        public FirmHaveServicesQueryPageViewModel FirmHaveServicesQueryPageViewModel => IoC.Resolve<FirmHaveServicesQueryPageViewModel>();
        public FirmsByStartDateWithServicesQueryPageViewModel FirmsByStartDateWithServicesQueryPageViewModel => IoC.Resolve<FirmsByStartDateWithServicesQueryPageViewModel>();
        public AbonentsByServiceRecievingDateQueryPageViewModel AbonentsByServiceRecievingDateQueryViewModel => IoC.Resolve<AbonentsByServiceRecievingDateQueryPageViewModel>();
        public AbonentInfoQueryPageViewModel AbonentInfoQueryPageViewModel => IoC.Resolve<AbonentInfoQueryPageViewModel>();
        public SumSizeFirmsQueryPageViewModel SumSizeFirmsQueryPageViewModel => IoC.Resolve<SumSizeFirmsQueryPageViewModel>();
        public FirmsCountByOwnTypeQueryPageViewModel FirmsCountByOwnTypeQueryPageViewModel => IoC.Resolve<FirmsCountByOwnTypeQueryPageViewModel>();
        public AbonentsByContractsSumQueryPageViewModel AbonentsByContractsSumQueryPageViewModel => IoC.Resolve<AbonentsByContractsSumQueryPageViewModel>();
        public AbonentsByContractsSumAndDateQueryPageViewModel AbonentsByContractsSumAndDateQueryPageViewModel => IoC.Resolve<AbonentsByContractsSumAndDateQueryPageViewModel>();
        public FirmsSumConnectionCostInflationQueryPageViewModel FirmsSumConnectionCostInflationQueryPageViewModel => IoC.Resolve<FirmsSumConnectionCostInflationQueryPageViewModel>();
        public FirmsSumConnectionCostMoreAvgQueryPageViewModel FirmsSumConnectionCostMoreAvgQueryPageViewModel => IoC.Resolve<FirmsSumConnectionCostMoreAvgQueryPageViewModel>();
        public AbonentTypePageViewModel AbonentTypePageViewModel => IoC.Resolve<AbonentTypePageViewModel>();
        public OwnTypePageViewModel OwnTypePageViewModel => IoC.Resolve<OwnTypePageViewModel>();
        public AbonentTypeCreateWindowViewModel AbonentTypeCreateWindowViewModel => IoC.Resolve<AbonentTypeCreateWindowViewModel>();
        public OwnTypeCreateWindowViewModel OwnTypeCreateWindowViewModel => IoC.Resolve<OwnTypeCreateWindowViewModel>();
        public ContractCreateWindowViewModel ContractCreateWindowViewModel => IoC.Resolve<ContractCreateWindowViewModel>();
        public UserUpdateWindowViewModel UserUpdateWindowViewModel => IoC.Resolve<UserUpdateWindowViewModel>();
        public FirmCreateWindowViewModel FirmCreateWindowViewModel => IoC.Resolve<FirmCreateWindowViewModel>();
        public FirmUpdateWindowViewModel FirmUpdateWindowViewModel => IoC.Resolve<FirmUpdateWindowViewModel>();
        public MaskQueryPageViewModel MaskQueryPageViewModel => IoC.Resolve<MaskQueryPageViewModel>();
        public CaseQueryPageViewModel CaseQueryPageViewModel => IoC.Resolve<CaseQueryPageViewModel>();
        public UnionQueryPageViewModel UnionQueryPageViewModel => IoC.Resolve<UnionQueryPageViewModel>();
        public InQueryPageViewModel InQueryPageViewModel => IoC.Resolve<InQueryPageViewModel>();
        public NotInQueryPageViewModel NotInQueryPageViewModel => IoC.Resolve<NotInQueryPageViewModel>();
        public UserAboutPageViewModel UserAboutPageViewModel => IoC.Resolve<UserAboutPageViewModel>();
        public ContractAbonentPageViewModel ContractAbonentPageViewModel => IoC.Resolve<ContractAbonentPageViewModel>();
    }
}
