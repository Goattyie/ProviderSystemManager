using ProviderSystemManager.DAL.Database;
using ProviderSystemManager.DAL.Models;

namespace ProviderSystemManager.DAL.TableCreators;

public class AbonentTypeCreator
{
    public static int Count => 7;
    public static void Init(ProviderDbContext context)
    {
        var abonentType1 = new AbonentType() {Name = "Частное лицо"};
        var abonentType2 = new AbonentType() { Name = "ВУЗ" };
        var abonentType3 = new AbonentType() { Name = "Школа" };
        var abonentType4 = new AbonentType() { Name = "Агентство" };
        var abonentType5 = new AbonentType() { Name = "Магазин" };
        var abonentType6 = new AbonentType() { Name = "Супермаркет" };
        var abonentType7 = new AbonentType() { Name = "Мастерская" };

        context.AbonentTypes?.Add(abonentType1);
        context.AbonentTypes?.Add(abonentType2);
        context.AbonentTypes?.Add(abonentType3);
        context.AbonentTypes?.Add(abonentType4);
        context.AbonentTypes?.Add(abonentType5);
        context.AbonentTypes?.Add(abonentType6);
        context.AbonentTypes?.Add(abonentType7);

        context.SaveChanges();
    }
}