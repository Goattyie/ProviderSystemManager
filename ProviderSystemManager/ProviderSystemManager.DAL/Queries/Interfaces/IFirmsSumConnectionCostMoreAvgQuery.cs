namespace ProviderSystemManager.DAL.Queries.Interfaces
{
    public record FirmsSumConnectionCostMoreAvgModel(string FirmName, double SumCost);
    public interface IFirmsSumConnectionCostMoreAvgQuery : IQuery<IEnumerable<FirmsSumConnectionCostMoreAvgModel>>
    {
    }
}
