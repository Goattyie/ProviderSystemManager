namespace ProviderSystemManager.DAL.Queries.Interfaces
{
    public record UnionModel(string Type, int Count);
    public interface IUnionQuery : IQuery<IEnumerable<UnionModel>>
    {
    }
}
