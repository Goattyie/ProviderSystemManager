using ProviderSystemManager.DAL.Database;
using ProviderSystemManager.DAL.Models;

namespace ProviderSystemManager.DAL.TableCreators;

public class FirmCreator
{
    public static void Init(ProviderDbContext dbContext)
    {
        var firm1 = new Firm()
        {
            Name = "Trinity", 
            Address = "ул. Пушкина д.15", 
            Telephone = "+37546213517", 
            OwnTypeId = 1,
            StartWorkingYear = 2002
        };
        
        var firm2 = new Firm()
        {
            Name = "Matrix", 
            Address = "ул. Кирова д.38", 
            Telephone = "+3784684628", 
            OwnTypeId = 2,
            StartWorkingYear = 2008
        };

        dbContext.Firms?.Add(firm1);
        dbContext.Firms?.Add(firm2);

        dbContext.SaveChanges();
    }
}