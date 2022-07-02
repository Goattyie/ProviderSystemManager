using Microsoft.EntityFrameworkCore;
using ProviderSystemManager.DAL.Database;
using ProviderSystemManager.DAL.Models;
using ProviderSystemManager.DAL.Repositories.Interfaces;

namespace ProviderSystemManager.DAL.Repositories;

public class UserRepository : AbstractRepository<User>, IUserRepository
{
    public UserRepository(ProviderDbContext dbContext) : base(dbContext) { }
    public override async Task Create(params User[] models)
    {
        var createUsersSqlQuery = models.Select(x => $"CREATE USER {x.Login} WITH SUPERUSER PASSWORD '{x.Password}';");
        var result = await DbContext.Database.ExecuteSqlRawAsync(string.Join(";", createUsersSqlQuery));

        await base.Create(models);
    }

    public override async Task Update(params User[] models)
    {
        var updateUsersSqlQuery = models.Select(x => $"UPDATE users SET role = {(int)x.Role}, password = '{x.Password}' where users.id = {x.Id}");
        var result = await DbContext.Database.ExecuteSqlRawAsync(string.Join(";", updateUsersSqlQuery));
    }

    public override async Task Remove(params User[] models)
    {
        await base.Remove(models);
    }
}