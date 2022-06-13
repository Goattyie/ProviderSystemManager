using Microsoft.EntityFrameworkCore;
using ProviderSystemManager.DAL.Models;
using ProviderSystemManager.DAL.Database;
using ProviderSystemManager.DAL.Repositories.Interfaces;

namespace ProviderSystemManager.DAL.Repositories;

public class FirmRepository : AbstractRepository<Firm>, IFirmRepository
{
    public FirmRepository(ProviderDbContext dbContext) : base(dbContext) { }

    public override async Task<IEnumerable<Firm>> Get() => await DataSet.Include(x => x.OwnType).AsNoTracking().ToListAsync();
    public override async Task<Firm> GetById(int id) => await DataSet.Include(x => x.OwnType).FirstOrDefaultAsync(x => x.Id == id);
}