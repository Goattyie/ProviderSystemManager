namespace ProviderSystemManager.DAL.Queries.Interfaces
{
    public record AbonentByContractsSumModel(string AbonentName, double SumConnectionCost);
    public interface IAbonentsByContractsSumQuery : IQuery<IEnumerable<AbonentByContractsSumModel>>
    {
    }
}
