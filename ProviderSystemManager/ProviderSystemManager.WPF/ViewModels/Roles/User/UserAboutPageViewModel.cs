using DevExpress.Mvvm;
using ProviderSystemManager.BLL.Services.Interfaces;
using ProviderSystemManager.Shared.Dtos.Get;
using ProviderSystemManager.WPF.Session;

namespace ProviderSystemManager.WPF.ViewModels.Roles.User
{
    internal class UserAboutPageViewModel : BindableBase
    {
        public UserAboutPageViewModel(IAbonentService service)
        {
            Dto = service.GetById(Session.User.Id).Result;
        }

        public AbonentGetDto Dto { get; set; }
    }
}
