namespace ProviderSystemManager.DAL.Queries.Interfaces
{
    public record InModel(int Id, DateTime ConnectionDate, string AbonentName, string AbonentEmail);
    public interface IInQuery : IQuery<IEnumerable<InModel>>
    {
    }

    public interface INotInQuery : IQuery<IEnumerable<InModel>>
    {
    }
}
