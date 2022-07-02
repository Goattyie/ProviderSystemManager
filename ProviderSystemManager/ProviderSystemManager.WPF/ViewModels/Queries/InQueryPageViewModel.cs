using DevExpress.Mvvm;
using ProviderSystemManager.DAL.Queries.Interfaces;
using System.Collections.ObjectModel;

namespace ProviderSystemManager.WPF.ViewModels.Queries
{
    internal class InQueryPageViewModel : BindableBase
    {
        private readonly IInQuery _query;

        public InQueryPageViewModel(IInQuery query)
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
