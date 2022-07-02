using DevExpress.Mvvm;
using ProviderSystemManager.DAL.Queries.Interfaces;
using System.Collections.ObjectModel;

namespace ProviderSystemManager.WPF.ViewModels.Queries
{
    internal class UnionQueryPageViewModel : BindableBase
    {
        private readonly IUnionQuery _query;

        public UnionQueryPageViewModel(IUnionQuery query)
        {
            _query = query;
            Data = new();
        }
        public ObservableCollection<UnionModel> Data { get; set; }

        public IAsyncCommand Execute => new AsyncCommand(async () =>
        {
            var result = await _query.Execute();

            Data.Clear();

            foreach (var item in result)
            {
                Data.Add(item);
            }
        });
    }
}
