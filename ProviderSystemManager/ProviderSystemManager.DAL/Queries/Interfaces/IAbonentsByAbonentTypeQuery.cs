using ProviderSystemManager.DAL.Models.Queries;

namespace ProviderSystemManager.DAL.Queries.Interfaces
{
    public interface IAbonentsByAbonentTypeQuery : IQuery<IEnumerable<EmailsByAbonentTypeModel>>
    {
    }
}
