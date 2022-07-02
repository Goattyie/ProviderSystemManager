using DevExpress.Mvvm;
using ProviderSystemManager.BLL.Services.Interfaces;
using ProviderSystemManager.DAL.Enums;
using ProviderSystemManager.Shared.Dtos.Get;
using ProviderSystemManager.Shared.Dtos.Update;
using ProviderSystemManager.WPF.Localization;
using ProviderSystemManager.WPF.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProviderSystemManager.WPF.ViewModels.Tables.CreateUpdate.Update
{
    internal class UserUpdateWindowViewModel : BindableBase
    {
        private readonly IUserService _service;

        public UserUpdateWindowViewModel(IUserService service)
        {
            _service = service;
            Roles = ((UserRole[])Enum.GetValues(typeof(UserRole))).ToList();
            Roles.RemoveAt(0);
            SelectedRole = Roles.FirstOrDefault();
            Dto = new();
        }


        public string Login { get; set; }
        public string Password { get; set; }
        public List<UserRole> Roles { get; set; }
        public UserRole SelectedRole { get; set; }
        public UserGetDto Dto { get; set; }

        public IAsyncCommand OnUpdate => new AsyncCommand(async () =>
        {
            var updateDto = new UserUpdateDto
            {
                Id = Dto.Id,
                Login = Dto.Login,
                Password = Dto.Password,
                Role = SelectedRole
            };

            try
            {
                var updateResult = await _service.UpdateAsync(updateDto);
                if (updateResult.CodeResult == Shared.CodeResult.Bad)
                {
                    MessageBoxManager.ShowError(updateResult.Errors.First());
                    return;
                }

                MessageBoxManager.ShowSuccess(Phrases.UpdateUserSuccess);

                Login = string.Empty;
                Password = string.Empty;
                SelectedRole = Roles.FirstOrDefault();
            }catch(Exception ex) { MessageBoxManager.ShowError(ex.Message); }
        });
    }
}
