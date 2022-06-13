namespace ProviderSystemManager.DAL.Models;

public class Firm : BaseModel
{
    public string Name { get; set; }
    public string Telephone { get; set; }
    public string Address { get; set; }
    public short StartWorkingYear{ get; set; }
    public int OwnTypeId { get; set; }
    public OwnType OwnType { get; set; }
    public virtual ICollection<Service> Services { get; set; }
    public virtual ICollection<Contract> Contracts { get; set; }
}