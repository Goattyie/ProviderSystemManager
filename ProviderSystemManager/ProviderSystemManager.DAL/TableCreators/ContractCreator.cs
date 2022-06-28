using ProviderSystemManager.DAL.Database;
using ProviderSystemManager.DAL.Models;

namespace ProviderSystemManager.DAL.TableCreators;

public class ContractCreator 
{
    public static int Count => 40000;
    public static void Init(ProviderDbContext dbContext)
    {
        var random = new Random();

        for(int i = 0; i < 40000; i++)
        {
            var contract = new Contract()
            {
                FirmId = random.Next(1, FirmCreator.Count),
                AbonentId = random.Next(1, AbonentCreator.Count),
                ConnectionCost = (decimal)(random.Next(1, 10000) + random.NextDouble()),
                ConnectionDate = DateOnly.FromDateTime(DateTime.Now.AddDays(random.Next(-1000, 0))),
                ForwardingCost = (decimal)(random.Next(1, 10000) + random.NextDouble())
            };

            dbContext.Contracts?.Add(contract);
        }

        dbContext.SaveChanges();
    }
}