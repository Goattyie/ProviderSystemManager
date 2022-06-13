namespace ProviderSystemManager.Shared.Dtos.Update;

public class ContractUpdateDto : IUpdateDto
{
    public int Id { get; set; }
    public int FirmId { get; set; }
    public int AbonentId { get; set; }
    public string ConnectionDate { get; set; }
    public decimal ConnectionCost { get; set; }
    public decimal ForwardingCost { get; set; }
}