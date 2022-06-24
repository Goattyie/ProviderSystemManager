﻿using ProviderSystemManager.WPF.DI;
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
        public AbonentsByAbonentTypeQueryPageViewModel GetAbonentsByTypeQueryPageViewModel => IoC.Resolve<AbonentsByAbonentTypeQueryPageViewModel>();
        public FirmsByOwnTypeQueryPageViewModel FirmNamesByOwnTypeQueryPageViewModel => IoC.Resolve<FirmsByOwnTypeQueryPageViewModel>();
        public FirmsByServiceRecievingDateQueryPageViewModel FirmServiceSizeByDateQueryPageViewModel => IoC.Resolve<FirmsByServiceRecievingDateQueryPageViewModel>();
        public ContractsInfoQueryPageViewModel ContractsInfoQueryPageViewModel => IoC.Resolve<ContractsInfoQueryPageViewModel>();
        public ServiceInfoQueryPageViewModel ServiceInfoQueryPageViewModel => IoC.Resolve<ServiceInfoQueryPageViewModel>();
        public ContractAbonentsEmailNotNullQueryPageViewModel ContractAbonentsEmailNotNullQueryPageViewModel => IoC.Resolve<ContractAbonentsEmailNotNullQueryPageViewModel>();
        public FirmHaveServicesQueryPageViewModel FirmHaveServicesQueryPageViewModel => IoC.Resolve<FirmHaveServicesQueryPageViewModel>();
        public FirmsByStartDateWithServicesQueryPageViewModel FirmsByStartDateWithServicesQueryPageViewModel => IoC.Resolve<FirmsByStartDateWithServicesQueryPageViewModel>();
    }
}
