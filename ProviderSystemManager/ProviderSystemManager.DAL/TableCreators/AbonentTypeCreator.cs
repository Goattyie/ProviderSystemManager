using ProviderSystemManager.DAL.Database;
using ProviderSystemManager.DAL.Models;

namespace ProviderSystemManager.DAL.TableCreators;

public class AbonentTypeCreator
{
    public static void Init(ProviderDbContext context)
    {
        var abonentType1 = new AbonentType() {Name = "Частное лицо"};
        var abonentType2 = new AbonentType() {Name = "ВУЗ"};

        context.AbonentTypes?.Add(abonentType1);
        context.AbonentTypes?.Add(abonentType2);

        context.SaveChanges();
    }
}