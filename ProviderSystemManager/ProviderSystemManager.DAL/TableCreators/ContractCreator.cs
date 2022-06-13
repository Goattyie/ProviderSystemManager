using ProviderSystemManager.DAL.Database;
using ProviderSystemManager.DAL.Models;

namespace ProviderSystemManager.DAL.TableCreators;

public class ContractCreator 
{
    public static void Init(ProviderDbContext dbContext)
    {
        var contract1 = new Contract()
        {
            FirmId = 1, 
            AbonentId = 1, 
            ConnectionCost = 123.1m, 
            ConnectionDate = DateOnly.FromDateTime(DateTime.Now),
            ForwardingCost = 111.23m
        };
        
        var contract2 = new Contract()
        {
            FirmId = 2, 
            AbonentId = 2, 
            ConnectionCost = 250, 
            ConnectionDate = DateOnly.FromDateTime(DateTime.Now),
            ForwardingCost = 600
        };
        
        var contract3 = new Contract()
        {
            FirmId = 1, 
            AbonentId = 2, 
            ConnectionCost = 445, 
            ConnectionDate = DateOnly.FromDateTime(DateTime.Now),
            ForwardingCost = 64.5m
        };

        dbContext.Contracts?.Add(contract1);
        dbContext.Contracts?.Add(contract2);
        dbContext.Contracts?.Add(contract3);

        dbContext.SaveChanges();
    }
}