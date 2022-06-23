namespace ProviderSystemManager.DAL.Queries.Interfaces
{
    public interface IQuery<TOut>
    {
        Task<TOut> Execute(params string[] @params);
    }
}
