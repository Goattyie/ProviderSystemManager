using ProviderSystemManager.DAL.Models.Queries;

namespace ProviderSystemManager.DAL.Queries.Interfaces
{
    public interface IFirmsByServiceRecievingDate : IQuery<IEnumerable<FirmService>>
    {
    }
}
