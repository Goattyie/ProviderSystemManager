using ProviderSystemManager.DAL.Database;
using ProviderSystemManager.DAL.Models;

namespace ProviderSystemManager.DAL.TableCreators;

public class AbonentCreator
{
    public static void Init(ProviderDbContext dbContext)
    {
        var abonent1 = new Abonent {Name = "З.В. Иванова", Address = "ул. Кирова д.4 кв.11", Email = "Ivanova@pic.com", AbonentTypeId = 2};
        var abonent2 = new Abonent {Name = "К.С. Петров", Address = "ул. Пушкина д.15 кв.32", Email = "Petrov@pic.com", AbonentTypeId = 2};
        var abonent3 = new Abonent {Name = "Л.Н. Сергеева", Address = "ул. Ленина д.12 кв.43", Email = "Sergeeva@pic.com", AbonentTypeId = 1};

        dbContext.Abonents?.Add(abonent1);
        dbContext.Abonents?.Add(abonent2);
        dbContext.Abonents?.Add(abonent3);

        dbContext.SaveChanges();
    }
}