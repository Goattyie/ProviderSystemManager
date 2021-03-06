using ProviderSystemManager.DAL.Models;

namespace ProviderSystemManager.DAL.Repositories.Interfaces;

public interface IRepository<TModel> where TModel : BaseModel
{
    public Task<IEnumerable<TModel>> GetAsync();
    public IEnumerable<TModel> Get();
    public Task<TModel> GetByIdAsync(int id);
    public TModel GetById(int id);
    public Task Create(params TModel[] models);
    public Task Update(params TModel[] models);
    public Task Remove(params TModel[] models);
    public IQueryable<TModel> GetQuery();
}