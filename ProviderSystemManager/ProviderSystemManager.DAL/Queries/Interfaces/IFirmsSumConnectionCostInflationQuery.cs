namespace ProviderSystemManager.DAL.Queries.Interfaces
{
    public record FirmsSumConnectionCostInflationModel (string FirmName, double BeforeInflation, double AfterInflation);
    public interface IFirmsSumConnectionCostInflationQuery : IQuery<IEnumerable<FirmsSumConnectionCostInflationModel>>
    {
    }
}
