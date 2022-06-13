namespace ProviderSystemManager.DAL.Models;

public class Contract : BaseModel
{
    public int FirmId { get; set; }
    public Firm Firm { get; set; }
    public int AbonentId { get; set; }
    public Abonent Abonent { get; set; }
    public DateOnly ConnectionDate { get; set; }
    public decimal ConnectionCost { get; set; }
    public decimal ForwardingCost { get; set; }
}