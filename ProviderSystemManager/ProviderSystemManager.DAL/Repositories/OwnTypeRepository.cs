using ProviderSystemManager.DAL.Models;
using ProviderSystemManager.DAL.Database;
using ProviderSystemManager.DAL.Repositories.Interfaces;

namespace ProviderSystemManager.DAL.Repositories;

public class OwnTypeRepository : AbstractRepository<OwnType>, IOwnTypeRepository
{
    public OwnTypeRepository(ProviderDbContext dbContext) : base(dbContext) { }
}