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


    public virtual async Task<TModel> GetByIdAsync(int id) => await DataSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    public virtual TModel GetById(int id) => DataSet.AsNoTracking().FirstOrDefault(x => x.Id == id);

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
        var objects = DataSet.Where(x => models.Select(m => m.Id).Contains(x.Id));

        foreach (var model in objects)
        {
            DbContext.Entry(model).State = EntityState.Detached;
        }

        DataSet.RemoveRange(models);
        await DbContext.SaveChangesAsync();
    }

    public virtual IQueryable<TModel> GetQuery() => DataSet.AsQueryable();
}