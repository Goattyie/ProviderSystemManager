using DevExpress.Mvvm;
using ProviderSystemManager.BLL.Services.Interfaces;
using ProviderSystemManager.DAL.Enums;
using ProviderSystemManager.Shared;
using ProviderSystemManager.WPF.Session;
using ProviderSystemManager.WPF.Utils;
using System;
using System.Configuration;
using System.Linq;
using System.Windows.Input;

namespace ProviderSystemManager.WPF.ViewModels
{
    internal class SignInWindowViewModel : BindableBase
    {
        private readonly IDbContextService _service;
        private readonly IUserService _userService;

        public SignInWindowViewModel(IDbContextService service, IUserService userService)
        {
            _service = service;
            _userService = userService;
        }

        public Action OnSuccessSignIn { get; set; }
        public string Login { get; set; } = "employee_1";
        public string Password { get; set; } = "1956";

        public ICommand SignInCommand => new AsyncCommand(async () =>
        {
            var dbConnection = string.Format(ConfigurationManager.ConnectionStrings["ProviderDB"].ConnectionString, Login, Password);
            var connectionResult = await _service.ChangeConnectionAsync(dbConnection);

            if (connectionResult.CodeResult == CodeResult.Bad)
            {
                MessageBoxManager.ShowError(connectionResult.Errors.First());
                return;
            }

            var userResponse = await _userService.GetByLoginAsync(Login);

            if(userResponse.CodeResult == CodeResult.Bad)
            {
                MessageBoxManager.ShowError(userResponse.Errors.First());
                return;
            }

            User.Id = userResponse.Result.Id;
            User.Login = userResponse.Result.Login;
            User.Password = userResponse.Result.Password;
            User.Role = Enum.Parse<UserRole>(userResponse.Result.UserRole);

            OnSuccessSignIn?.Invoke();
        });
    }
}
