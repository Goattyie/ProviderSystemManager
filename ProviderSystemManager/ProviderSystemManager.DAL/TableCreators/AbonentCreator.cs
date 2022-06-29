using ProviderSystemManager.DAL.Database;
using ProviderSystemManager.DAL.Models;

namespace ProviderSystemManager.DAL.TableCreators;

public class AbonentCreator
{
    public static int Count => 100;
    public static string[] Initials => new string[]
    {
        "А.",
        "Б.",
        "С.",
        "Д.",
        "Е.",
        "П.",
        "К.",
        "Р.",
        "В.",
        "З.",
        "Ф.",
        "Л.",
        "Н.",
        "О.",
        "И.",
        "Я."
    };
    public static string[] SecondNames => new string[]
    {
        "Сергева",
        "Сергеев",
        "Иванова",
        "Иванов",
        "Мирова",
        "Миров",
        "Добролюбов",
        "Добролюбова",
        "Синеев",
        "Синеева",
        "Хим",
        "Орладно",
        "Дорин",
        "Дорина",
        "Колесников",
        "Колестикова",
        "Павлолюбов",
        "Павлолюбова",
        "Коновалов",
        "Коновалова"
    };

    public static void Init(ProviderDbContext dbContext)
    {
        var random = new Random();

        for(int i = 0; i < Count; i++)
        {
            var firstInitial = Initials[random.Next(Initials.Length - 1)];
            var secondInitial = Initials[random.Next(Initials.Length - 1)];
            var secondName = SecondNames[random.Next(SecondNames.Length - 1)];
            var street = FirmCreator.StreetNames[random.Next(FirmCreator.StreetNames.Length - 1)];
            var abonent = new Abonent { Name = $"{firstInitial} {secondInitial} {secondName}", Address = $"ул. {street} д.{i * 10} кв.{i % 7}", Email = $"test{i}@pic.com", AbonentTypeId = random.Next(1, AbonentTypeCreator.Count) };
       
            dbContext.Abonents?.Add(abonent);
        }

        dbContext.SaveChanges();
    }
}