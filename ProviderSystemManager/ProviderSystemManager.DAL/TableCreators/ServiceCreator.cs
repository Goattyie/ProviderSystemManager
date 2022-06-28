using ProviderSystemManager.DAL.Database;
using ProviderSystemManager.DAL.Models;

namespace ProviderSystemManager.DAL.TableCreators;

public class ServiceCreator
{
    public static int Count => 40000;
    public static void Init(ProviderDbContext dbContext)
    {
        var random = new Random();

        for(int i = 0; i < Count; i++)
        {
            var service = new Service { AbonentId = random.Next(1, AbonentCreator.Count), Size = random.Next(1, 10000) + random.NextDouble(), RecievingDate = DateOnly.FromDateTime(DateTime.Now.AddDays(random.Next(-1000, 0))), FirmId = random.Next(1, FirmCreator.Count) };
        
            dbContext.Services?.Add(service);
        }

        dbContext.SaveChanges();
    }
}