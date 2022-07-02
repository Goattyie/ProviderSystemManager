using Microsoft.EntityFrameworkCore;
using ProviderSystemManager.DAL.Database;
using ProviderSystemManager.DAL.QueryCreators;
using ProviderSystemManager.DAL.TableCreators;

namespace ProviderSystemManager.DAL;

public class DbInitializer
{
    public static void Initialize(ProviderDbContext dbContext)
    {
        dbContext.Database.EnsureDeleted();
        dbContext.Database.Migrate();

        QueryCreator.Init(dbContext);
        UserCreator.Init(dbContext);
        OwnTypeCreator.Init(dbContext);
        AbonentTypeCreator.Init(dbContext);
        AbonentCreator.Init(dbContext);
        FirmCreator.Init(dbContext);
        ContractCreator.Init(dbContext);
        ServiceCreator.Init(dbContext);
    }
}