namespace ProviderSystemManager.DAL.Models;

public class Service : BaseModel
{
    public int AbonentId { get; set; }
    public Abonent Abonent { get; set; }
    public DateOnly RecievingDate { get; set; }
    public double Size { get; set; }
    public int FirmId { get; set; }
    public Firm Firm { get; set; }
}