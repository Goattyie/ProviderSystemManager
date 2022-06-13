namespace ProviderSystemManager.DAL.Models;

public class Abonent : BaseModel
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public int AbonentTypeId { get; set; }
    public AbonentType AbonentType { get; set; }
    public virtual ICollection<Service> Services { get; set; }
    public virtual ICollection<Contract> Contracts { get; set; }
}