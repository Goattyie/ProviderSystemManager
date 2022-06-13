using DevExpress.Mvvm;
using ProviderSystemManager.BLL.Services.Interfaces;
using ProviderSystemManager.DAL.Enums;
using ProviderSystemManager.Shared.Dtos.Create;
using ProviderSystemManager.Shared.Dtos.Get;
using ProviderSystemManager.WPF.Localization;
using ProviderSystemManager.WPF.Utils;
using System;
using System.Linq;
using System.Windows.Input;

namespace ProviderSystemManager.WPF.ViewModels.Tables.CreateUpdate
{
    internal class UserCreateUpdateWindowViewModel : BindableBase
    {
        private readonly IUserService _service;

        public event Action<UserGetDto> OnUserCreate;

        public UserCreateUpdateWindowViewModel(IUserService service)
        {
            _service = service;
            Roles = (UserRole[])Enum.GetValues(typeof(UserRole));
            SelectedRole = Roles.FirstOrDefault();
        }


        public string Login { get; set; }
        public string Password { get; set; }
        public UserRole[] Roles { get; set; }
        public UserRole SelectedRole { get; set; }

        public ICommand OnCreate => new AsyncCommand(async () => 
        {
            var createDto = new UserCreateDto
            {
                Login = Login,
                Password = Password,
                Role = (int)SelectedRole
            };

            var createResult = await _service.CreateAsync(createDto);

            if(createResult.CodeResult == Shared.CodeResult.Bad)
            {
                MessageBoxManager.ShowError(createResult.Errors.First());
                return;
            }

            MessageBoxManager.ShowSuccess(Phrases.CreateUserSuccess);

            Login = string.Empty;
            Password = string.Empty;
            SelectedRole = Roles.FirstOrDefault();

            OnUserCreate?.Invoke(createResult.Result);
        });
    }
}
