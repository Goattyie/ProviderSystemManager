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

            #region Services

            services.AddTransient<IContractService, ContractService>();
            services.AddTransient<IFirmService, FirmService>();
            services.AddTransient<IDbContextService, DbContextService>();
            services.AddTransient<IFirmService, FirmService>();
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
