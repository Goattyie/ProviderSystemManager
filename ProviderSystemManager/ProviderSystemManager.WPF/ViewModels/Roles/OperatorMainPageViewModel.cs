using DevExpress.Mvvm;
using ProviderSystemManager.WPF.Views.Tables;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProviderSystemManager.WPF.ViewModels.Roles
{
    internal class OperatorMainPageViewModel : BindableBase
    {
        public OperatorMainPageViewModel(FirmPage firmPage)
        {
            CurrentTablePage = firmPage;
        }

        public Page CurrentTablePage { get; set; }
    }
}
