namespace ProviderSystemManager.DAL.Queries.Interfaces
{
    public record MaskModel(string FirmName, int Count);
    public interface IMaskQuery : IQuery<IEnumerable<MaskModel>>
    {
    }
}
