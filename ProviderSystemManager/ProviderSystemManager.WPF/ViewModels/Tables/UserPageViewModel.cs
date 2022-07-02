using DevExpress.Mvvm;
using ProviderSystemManager.BLL.Services;
using ProviderSystemManager.BLL.Services.Interfaces;
using ProviderSystemManager.Shared.Dtos.Get;
using ProviderSystemManager.WPF.DI;
using ProviderSystemManager.WPF.Utils;
using ProviderSystemManager.WPF.ViewModels.Tables.CreateUpdate;
using ProviderSystemManager.WPF.Views.Tables.CreateUpdate;
using ProviderSystemManager.WPF.Views.Tables.CreateUpdate.Update;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProviderSystemManager.WPF.ViewModels.Tables
{
    internal class UsersPageViewModel : BindableBase
    {
        private readonly IUserService _service;

        public UsersPageViewModel(IUserService service)
        {
            _service = service;
            Users = new(service.Get().Result);
            
            IoC.Resolve<UserCreateUpdateWindowViewModel>().OnUserCreate += (obj) => Users.Add(obj);

            UserService.OnUpdate += () =>
            {
                Users.Clear();

                var data = service.Get().Result;

                foreach (var obj in data)
                    Users.Add(obj);
            };
        }


        public ObservableCollection<UserGetDto> Users { get; set; }
        public UserGetDto SelectedUser { get; set; }

        public ICommand OnCreate => new DelegateCommand(() =>
        {
            new UserCreateUpdateWindow().Show();
        });

        public ICommand OnUpdate => new DelegateCommand(() =>
        {
            if (SelectedUser is null)
                return;

            new UserUpdateWindow(SelectedUser).Show();
        });

        public ICommand OnDelete => new AsyncCommand(async () =>
        {
            if (SelectedUser is null)
                return;

            var deleteResult = await _service.RemoveAsync(SelectedUser.Id);

            if (deleteResult.CodeResult == Shared.CodeResult.Bad)
            {
                MessageBoxManager.ShowError(deleteResult.Errors.First());
                return;
            }

            Users.Remove(SelectedUser);
        });
    }
}
