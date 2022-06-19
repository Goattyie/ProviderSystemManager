using Microsoft.EntityFrameworkCore;
using ProviderSystemManager.DAL.Repositories.Interfaces;
using ProviderSystemManager.DAL.Models;
using ProviderSystemManager.DAL.Database;

namespace ProviderSystemManager.DAL.Repositories;

public class ServiceRepository : AbstractRepository<Service>, IServiceRepository
{
    public ServiceRepository(ProviderDbContext dbContext) : base(dbContext)
    {
    }

    public override async Task<IEnumerable<Service>> GetAsync() =>
        await DataSet.Include(x => x.Abonent)
            .ThenInclude(x => x.AbonentType)
            .AsNoTracking()
            .ToListAsync();

    public override IEnumerable<Service> Get() =>
            DataSet.Include(x => x.Abonent)
                .ThenInclude(x => x.AbonentType)
                .AsNoTracking();
}