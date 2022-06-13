using ProviderSystemManager.DAL.Database;
using ProviderSystemManager.DAL.Models;

namespace ProviderSystemManager.DAL.TableCreators;

public class OwnTypeCreator
{
    public static void Init(ProviderDbContext context)
    {
        var ownType1 = new OwnType() {Name = "Частная"};
        var ownType2 = new OwnType() {Name = "Собственная"};

        context.OwnTypes?.Add(ownType1);
        context.OwnTypes?.Add(ownType2);

        context.SaveChanges();
    }
}