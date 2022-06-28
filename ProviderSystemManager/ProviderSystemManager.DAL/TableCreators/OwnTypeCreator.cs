using ProviderSystemManager.DAL.Database;
using ProviderSystemManager.DAL.Models;

namespace ProviderSystemManager.DAL.TableCreators;

public class OwnTypeCreator
{
    public static int Count => 3;
    public static void Init(ProviderDbContext context)
    {
        var ownType1 = new OwnType() {Name = "Частная"};
        var ownType2 = new OwnType() { Name = "Собственная" };
        var ownType3 = new OwnType() { Name = "Государственная" };

        context.OwnTypes?.Add(ownType1);
        context.OwnTypes?.Add(ownType2);
        context.OwnTypes?.Add(ownType3);

        context.SaveChanges();
    }
}