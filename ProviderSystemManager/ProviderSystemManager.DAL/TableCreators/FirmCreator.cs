using ProviderSystemManager.DAL.Database;
using ProviderSystemManager.DAL.Models;

namespace ProviderSystemManager.DAL.TableCreators;

public class FirmCreator
{
    public static int Count => 20000;
    private static string[] ProviderNames = new string[] 
    { 
        "Trinity", 
        "Matrix", 
        "Билайн", 
        "MTC", 
        "A Связь", 
        "Пром канал",
        "100с",
        "Быстрый старт",
        "Spike",
        "Oww Data",
        "Faster",
        "No slow Ethernet",
        "Sp. Frankov",
        "YTL",
        "SST",
        "QWE"
    };
    public static string[] StreetNames = new string[] 
    {
        "Пушкина",
        "Куйбышева",
        "Ватутина",
        "Титова",
        "Гурова",
        "Илонова",
        "Битова",
        "Сергова",
        "Синяя",
        "Ленина",
        "Кирова",
        "Малова",
        "Большевиков",
        "Иванова",
        "Павлова",
        "Михеева",
        "Карда",
        "Кумова",
        "Семейная",
        "Дружба",
        "Дружная",
        "Веселова",
        "Смирнова",
        "Каталова"
    };
    public static void Init(ProviderDbContext dbContext)
    {
        var ownTypeId = OwnTypeCreator.Count;
        var random = new Random();

        for (int i = 0; i < Count; i++)
        {
            var street = StreetNames[random.Next(StreetNames.Length - 1)];
            var name = ProviderNames[random.Next(ProviderNames.Length - 1)];

            if(ownTypeId == 0)
                ownTypeId = OwnTypeCreator.Count;

            var firm = new Firm()
            {
                Name = name,
                Address = $"ул. {street} д. {i * 13}",
                Telephone = $"071{random.Next(1000000, 9999999)}",
                OwnTypeId = ownTypeId,
                StartWorkingYear = (short)random.Next(1995, 2022)
            };

            ownTypeId--;

            dbContext.Firms?.Add(firm);

        }

        dbContext.SaveChanges();
    }
}