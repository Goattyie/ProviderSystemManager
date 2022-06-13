using ProviderSystemManager.DAL.Database;
using ProviderSystemManager.DAL.Models;

namespace ProviderSystemManager.DAL.TableCreators;

public class ServiceCreator
{
    public static void Init(ProviderDbContext dbContext)
    {
        var service1 = new Service{AbonentId = 1, Size = 3400, RecievingDate = DateOnly.FromDateTime(DateTime.Now), FirmId = 1};
        var service2 = new Service{AbonentId = 2, Size = 1700, RecievingDate = DateOnly.FromDateTime(DateTime.Now), FirmId = 2};
        var service3 = new Service{AbonentId = 3, Size = 2500, RecievingDate = DateOnly.FromDateTime(DateTime.Now), FirmId = 1};

        dbContext.Services?.Add(service1);
        dbContext.Services?.Add(service2);
        dbContext.Services?.Add(service3);

        dbContext.SaveChanges();
    }
}