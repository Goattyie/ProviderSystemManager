using Microsoft.EntityFrameworkCore;
using ProviderSystemManager.DAL.Models;
using ProviderSystemManager.DAL.Database;
using ProviderSystemManager.DAL.Repositories.Interfaces;

namespace ProviderSystemManager.DAL.Repositories;

public class ContractRepository : AbstractRepository<Contract>, IContractRepository
{
    public ContractRepository(ProviderDbContext dbContext) : base(dbContext)
    {
    }

    public override async Task<IEnumerable<Contract>> GetAsync() =>
        await DataSet.Include(x => x.Firm)
            .ThenInclude(f => f.OwnType)
            .Include(x => x.Abonent)
            .ThenInclude(a => a.AbonentType).AsNoTracking().ToListAsync();

    public override IEnumerable<Contract> Get() =>
        DataSet.Include(x => x.Firm)
            .ThenInclude(f => f.OwnType)
            .Include(x => x.Abonent)
            .ThenInclude(a => a.AbonentType).AsNoTracking();

    public override async Task<Contract> GetByIdAsync(int id) => await DataSet.Include(x => x.Firm)
        .ThenInclude(f => f.OwnType)
        .Include(x => x.Abonent)
        .ThenInclude(a => a.AbonentType)
        .FirstOrDefaultAsync(x => x.Id == id);
}