using DevExpress.Mvvm;
using ProviderSystemManager.DAL.Queries.Interfaces;
using System.Collections.ObjectModel;

namespace ProviderSystemManager.WPF.ViewModels.Queries
{
    internal class NotInQueryPageViewModel : BindableBase
    {
        private readonly INotInQuery _query;

        public NotInQueryPageViewModel(INotInQuery query)
        {
            _query = query;
            Data = new();
        }
        public ObservableCollection<InModel> Data { get; set; }
        public string Value { get; set; }

        public IAsyncCommand Execute => new AsyncCommand(async () =>
        {
            var result = await _query.Execute(Value);

            Data.Clear();

            foreach (var item in result)
            {
                Data.Add(item);
            }
        });
    }
}
