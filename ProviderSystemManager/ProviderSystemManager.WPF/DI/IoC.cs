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
using ProviderSystemManager.WPF.ViewModels.Admin;
using ProviderSystemManager.WPF.Views.Tables;
using ProviderSystemManager.WPF.ViewModels.Tables;
using ProviderSystemManager.WPF.ViewModels.Tables.CreateUpdate;

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
            services.AddTransient<UsersPage>();

            #endregion

            #region ViewModels

            services.AddTransient<SignInWindowViewModel>();
            services.AddTransient<MainWindowViewModel>();
            services.AddTransient<AdminMainPageViewModel>();
            services.AddTransient<UsersPageViewModel>();
            services.AddSingleton<UserCreateUpdateWindowViewModel>();

            #endregion

            #region Database

            var dbConnection = string.Format(ConfigurationManager.ConnectionStrings["ProviderDB"].ConnectionString, "postgres", "1956");

            services.AddDbContext<ProviderDbContext>(opt => opt.UseNpgsql(dbConnection));

            #endregion

            #region Repositories

            services.AddTransient<IUserRepository, UserRepository>();

            #endregion

            #region Services

            services.AddTransient<IDbContextService, DbContextService>();
            services.AddTransient<IUserService, UserService>();

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
