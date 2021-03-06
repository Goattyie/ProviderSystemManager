using Microsoft.EntityFrameworkCore;
using ProviderSystemManager.DAL.Database;
using ProviderSystemManager.DAL.Models;
using ProviderSystemManager.DAL.Repositories.Interfaces;

namespace ProviderSystemManager.DAL.Repositories;

public class AbonentRepository : AbstractRepository<Abonent>, IAbonentRepository
{
    public AbonentRepository(ProviderDbContext dbContext) : base(dbContext) { }
    public override async Task<IEnumerable<Abonent>> GetAsync() => await DataSet.Include(x => x.AbonentType).AsNoTracking().ToListAsync();
    public override IEnumerable<Abonent> Get() => DataSet.Include(x => x.AbonentType).AsNoTracking();

    public override async Task<Abonent> GetByIdAsync(int id) =>
        await DataSet.Include(x => x.AbonentType).FirstOrDefaultAsync(x => x.Id == id);

    public override Abonent GetById(int id) =>
        DataSet.Include(x => x.AbonentType).FirstOrDefault(x => x.Id == id);

}