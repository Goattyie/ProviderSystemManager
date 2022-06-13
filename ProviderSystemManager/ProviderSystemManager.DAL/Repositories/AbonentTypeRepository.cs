using ProviderSystemManager.DAL.Database;
using ProviderSystemManager.DAL.Models;
using ProviderSystemManager.DAL.Repositories.Interfaces;

namespace ProviderSystemManager.DAL.Repositories;

public class AbonentTypeRepository : AbstractRepository<AbonentType>, IAbonentTypeRepository
{
    public AbonentTypeRepository(ProviderDbContext dbContext) : base(dbContext) { }
}