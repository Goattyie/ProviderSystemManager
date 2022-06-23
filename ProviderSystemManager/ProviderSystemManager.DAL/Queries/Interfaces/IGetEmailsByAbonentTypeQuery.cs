using ProviderSystemManager.DAL.Models.Queries;

namespace ProviderSystemManager.DAL.Queries.Interfaces
{
    public interface IGetEmailsByAbonentTypeQuery : IQuery<IEnumerable<EmailsByAbonentTypeModel>>
    {
    }
}
