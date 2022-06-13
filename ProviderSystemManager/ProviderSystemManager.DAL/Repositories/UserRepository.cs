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
        var createUsersSqlQuery = models.Select(x => $"CREATE USER {x.Login} WITH SUPERUSER PASSWORD '{x.Password}'; GRANT {x.Role.ToString()} TO {x.Login};");
        var result = await DbContext.Database.ExecuteSqlRawAsync(string.Join(";", createUsersSqlQuery));

        await base.Create(models);
    }

    public override async Task Remove(params User[] models)
    {
        var removeUsersSqlQuery = models.Select(x => $"DROP USER {x.Login};");
        var result = await DbContext.Database.ExecuteSqlRawAsync(string.Join(";", removeUsersSqlQuery));

        await base.Remove(models);
    }
}