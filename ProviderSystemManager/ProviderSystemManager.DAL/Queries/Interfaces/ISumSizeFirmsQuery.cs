namespace ProviderSystemManager.DAL.Queries.Interfaces
{
    public record SumSizeFirmsModel(string FirmName, double SumSize);
    public interface ISumSizeFirmsQuery : IQuery<IEnumerable<SumSizeFirmsModel>>
    {
    }
}
