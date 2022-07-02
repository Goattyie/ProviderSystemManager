using ProviderSystemManager.BLL.Services;
using ProviderSystemManager.BLL.Services.Interfaces;
using ProviderSystemManager.DAL.Enums;
using ProviderSystemManager.Shared.Dtos.Get;
using ProviderSystemManager.WPF.DI;
using ProviderSystemManager.WPF.ViewModels.Tables.CreateUpdate.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProviderSystemManager.WPF.Views.Tables.CreateUpdate.Update
{
    /// <summary>
    /// Interaction logic for UserUpdateWindow.xaml
    /// </summary>
    public partial class UserUpdateWindow : Window
    {
        public UserUpdateWindow(UserGetDto user)
        {
            InitializeComponent();

            var vm = IoC.Resolve<UserUpdateWindowViewModel>();

            vm.Dto = user;

            DataContext = vm;
        }
    }
}
