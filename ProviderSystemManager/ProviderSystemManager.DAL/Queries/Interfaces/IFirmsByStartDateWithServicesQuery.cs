using ProviderSystemManager.DAL.Models.Queries;

namespace ProviderSystemManager.DAL.Queries.Interfaces
{
    public interface IFirmsByStartDateWithServicesQuery : IQuery<IEnumerable<FirmService>>
    {
    }
}
