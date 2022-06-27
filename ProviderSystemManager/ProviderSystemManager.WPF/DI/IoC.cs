using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProviderSystemManager.BLL.Services;
using ProviderSystemManager.DAL;
using ProviderSystemManager.DAL.Database;
using ProviderSystemManager.WPF.ViewModels;
using System.Configuration;
using ProviderSystemManager.BLL.Services.Interfaces;
using ProviderSystemManager.BLL.MappingConfiguration;
using ProviderSystemManager.DAL.Repositories.Interfaces;
using ProviderSystemManager.DAL.Repositories;
using ProviderSystemManager.WPF.Views.Admin;
using ProviderSystemManager.WPF.ViewModels.Roles;
using ProviderSystemManager.WPF.Views.Tables;
using ProviderSystemManager.WPF.ViewModels.Tables;
using ProviderSystemManager.WPF.ViewModels.Tables.CreateUpdate;
using ProviderSystemManager.WPF.Views.Roles;
using ProviderSystemManager.WPF.Views.Queries;
using ProviderSystemManager.WPF.ViewModels.Queries;
using ProviderSystemManager.DAL.Models.Queries;
using ProviderSystemManager.DAL.Queries.Interfaces;
using ProviderSystemManager.DAL.Queries;

namespace ProviderSystemManager.WPF.DI
{
    internal static class IoC
    {
        private static readonly ServiceProvider _provider;

        static IoC()
        {
            var services = new ServiceCollection();

            #region Views

            services.AddTransient<AdminMainPage>();
            services.AddTransient<OperatorMainPage>();
            services.AddTransient<UserMainPage>();
            services.AddTransient<UsersPage>();
            services.AddTransient<FirmPage>();
            services.AddTransient<AbonentPage>();
            services.AddTransient<ContractPage>();
            services.AddTransient<ServicePage>();
            services.AddTransient<CommonQueryPage>();
            services.AddTransient<GetAbonentsByTypeQueryPage>();
            services.AddTransient<FirmNamesByOwnTypeQueryPage>();
            services.AddTransient<FirmServiceSizeByDateQueryPage>();
            services.AddTransient<ContractsInfoQueryPage>();
            services.AddTransient<ServiceInfoQueryPage>();
            services.AddTransient<ContractAbonentsEmailNotNullQueryPage>();
            services.AddTransient<FirmHaveServicesQueryPage>();
            services.AddTransient<FirmsByStartDateWithServicesQueryPage>();
            services.AddTransient<AbonentsByServiceRecievingDateQueryPage>();
            services.AddTransient<AbonentInfoQueryPage>();
            services.AddTransient<SumSizeFirmsQueryPage>();
            services.AddTransient<FirmsCountByOwnTypeQueryPage>();
            services.AddTransient<AbonentsByContractsSumQueryPage>();
            services.AddTransient<AbonentsByContractsSumAndDateQueryPage>();
            services.AddTransient<FirmsSumConnectionCostInflationQueryPage>();
            services.AddTransient<FirmsSumConnectionCostMoreAvgQueryPage>();

            #endregion

            #region ViewModels

            services.AddTransient<ContractPageViewModel>();
            services.AddTransient<SignInWindowViewModel>();
            services.AddTransient<MainWindowViewModel>();
            services.AddTransient<OperatorMainPageViewModel>();
            services.AddTransient<AdminMainPageViewModel>();
            services.AddTransient<UserMainPageViewModel>();
            services.AddTransient<UsersPageViewModel>();
            services.AddTransient<FirmPageViewModel>();
            services.AddTransient<AbonentPageViewModel>();
            services.AddTransient<ServicePageViewModel>();
            services.AddSingleton<UserCreateUpdateWindowViewModel>();
            services.AddTransient<CommonQueryPageViewModel>();
            services.AddTransient<AbonentsByAbonentTypeQueryPageViewModel>();
            services.AddTransient<FirmsByOwnTypeQueryPageViewModel>();
            services.AddTransient<FirmsByServiceRecievingDateQueryPageViewModel>();
            services.AddTransient<ContractsInfoQueryPageViewModel>();
            services.AddTransient<ServiceInfoQueryPageViewModel>();
            services.AddTransient<ContractAbonentsEmailNotNullQueryPageViewModel>();
            services.AddTransient<FirmHaveServicesQueryPageViewModel>();
            services.AddTransient<FirmsByStartDateWithServicesQueryPageViewModel>();
            services.AddTransient<AbonentsByServiceRecievingDateQueryPageViewModel>();
            services.AddTransient<AbonentInfoQueryPageViewModel>();
            services.AddTransient<SumSizeFirmsQueryPageViewModel>();
            services.AddTransient<FirmsCountByOwnTypeQueryPageViewModel>();
            services.AddTransient<AbonentsByContractsSumQueryPageViewModel>();
            services.AddTransient<AbonentsByContractsSumAndDateQueryPageViewModel>();
            services.AddTransient<FirmsSumConnectionCostInflationQueryPageViewModel>();
            services.AddTransient<FirmsSumConnectionCostMoreAvgQueryPageViewModel>();

            #endregion

            #region Database

            var dbConnection = string.Format(ConfigurationManager.ConnectionStrings["ProviderDB"].ConnectionString, "postgres", "1956");

            services.AddDbContext<ProviderDbContext>(opt => opt.UseNpgsql(dbConnection));

            #endregion

            #region Repositories

            services.AddTransient<IContractRepository, ContractRepository>();
            services.AddTransient<IFirmRepository, FirmRepository>();
            services.AddTransient<IFirmRepository, FirmRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IOwnTypeRepository, OwnTypeRepository>();
            services.AddTransient<IAbonentRepository, AbonentRepository>();
            services.AddTransient<IServiceRepository, ServiceRepository>();
            services.AddTransient<IAbonentTypeRepository, AbonentTypeRepository>();

            #endregion

            #region Queries

            services.AddTransient<IAbonentsByAbonentTypeQuery, AbonentsByAbonentTypeQuery>();
            services.AddTransient<IFirmsByOwnType, FirmsByOwnType>();
            services.AddTransient<IFirmsByServiceRecievingDate, FirmsByServiceRecievingDate>();
            services.AddTransient<IContractsInfoQuery, ContractsInfoQuery>();
            services.AddTransient<IServiceInfoQuery, ServiceInfoQuery>();
            services.AddTransient<IContractAbonentsEmailNotNullQuery, ContractAbonentsEmailNotNullQuery>();
            services.AddTransient<IFirmHaveServicesQuery, FirmHaveServicesQuery>();
            services.AddTransient<IFirmsByStartDateWithServicesQuery, FirmsByStartDateWithServicesQuery>();
            services.AddTransient<IAbonentsByServiceRecievingDateQuery, AbonentsByServiceRecievingDateQuery>();
            services.AddTransient<IAbonentInfoQuery, AbonentInfoQuery>();
            services.AddTransient<ISumSizeFirmsQuery, SumSizeFirmsQuery>();
            services.AddTransient<IFirmsCountByOwnTypeQuery, FirmsCountByOwnTypeQuery>();
            services.AddTransient<IAbonentsByContractsSumQuery, AbonentsByContractsSumQuery>();
            services.AddTransient<IAbonentsByContractsSumAndDateQuery, AbonentsByContractsSumAndDateQuery>();
            services.AddTransient<IFirmsSumConnectionCostInflationQuery, FirmsSumConnectionCostInflationQuery>();
            services.AddTransient<IFirmsSumConnectionCostMoreAvgQuery, FirmsSumConnectionCostMoreAvgQuery>();

            #endregion

            #region Services

            services.AddTransient<IContractService, ContractService>();
            services.AddTransient<IFirmService, BLL.Services.FirmService>();
            services.AddTransient<IDbContextService, DbContextService>();
            services.AddTransient<IFirmService, BLL.Services.FirmService>();
            services.AddTransient<IOwnTypeService, OwnTypeService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAbonentService, AbonentService>();
            services.AddTransient<IServiceService, ServiceService>();
            services.AddTransient<IAbonentTypeService, AbonentTypeService>();

            #endregion

            #region AutoMapper

            services.AddAutoMapper(typeof(DtoModelProfile));

            #endregion

            _provider = services.BuildServiceProvider();

            var dbContext = _provider.GetRequiredService<ProviderDbContext>();

            DbInitializer.Initialize(dbContext);
        }

        public static T Resolve<T>() => _provider.GetRequiredService<T>();
    }
}
