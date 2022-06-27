namespace ProviderSystemManager.DAL.Queries.Interfaces
{
    public record AbonentsByServiceRecievingDateModel(string AbonentName, double Size);
    public interface IAbonentsByServiceRecievingDateQuery : IQuery<IEnumerable<AbonentsByServiceRecievingDateModel>>
    {
    }
}
