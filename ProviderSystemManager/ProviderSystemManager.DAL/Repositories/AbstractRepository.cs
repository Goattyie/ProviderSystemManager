using Microsoft.EntityFrameworkCore;
using ProviderSystemManager.DAL.Database;
using ProviderSystemManager.DAL.Models;
using ProviderSystemManager.DAL.Repositories.Interfaces;

namespace ProviderSystemManager.DAL.Repositories;

public abstract class AbstractRepository<TModel> : IRepository<TModel> where TModel : BaseModel
{
    protected DbSet<TModel> DataSet { get; }
    protected ProviderDbContext DbContext { get; }

    public AbstractRepository(ProviderDbContext dbContext)
    {
        DbContext = dbContext;
        DataSet = dbContext.Set<TModel>();
    }

    public virtual async Task<IEnumerable<TModel>> GetAsync() => await DataSet.AsNoTracking().ToListAsync();
    public virtual IEnumerable<TModel> Get() => DataSet.AsNoTracking();


    public virtual async Task<TModel> GetById(int id) => await DataSet.FindAsync(id);

    public virtual async Task Create(params TModel[] models)
    {
        await DataSet.AddRangeAsync(models);
        await DbContext.SaveChangesAsync();
    }

    public virtual async Task Update(params TModel[] models)
    {
        DataSet.UpdateRange(models);
        await DbContext.SaveChangesAsync();
    }

    public virtual async Task Remove(params TModel[] models)
    {
        DataSet.RemoveRange(models);
        await DbContext.SaveChangesAsync();
    }

    public virtual IQueryable<TModel> GetQuery() => DataSet.AsQueryable();
}