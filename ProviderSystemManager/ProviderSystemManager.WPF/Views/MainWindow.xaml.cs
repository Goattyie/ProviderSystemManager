using ProviderSystemManager.WPF.Utils;
using ProviderSystemManager.WPF.Views;
using System;
using System.Windows;

namespace ProviderSystemManager.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var vm = new ViewModelLocator().MainWindowViewModel;

            DataContext = vm;

            vm.OnExitAction = new Action(() =>
            {
                new SignInWindow().Show();
                Close();
            });
        }
    }
}
