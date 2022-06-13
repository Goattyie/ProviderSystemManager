namespace ProviderSystemManager.Shared.Dtos.Get;

public class ContractGetDto : IGetDto
{
    public int Id { get; set; }
    public FirmGetDto Firm { get; set; }
    public AbonentGetDto Abonent { get; set; }
    public string ConnectionDate { get; set; }
    public decimal ConnectionCost { get; set; }
    public decimal ForwardingCost { get; set; }
}