namespace ProviderSystemManager.Shared.Dtos.Create;

public class ContractCreateDto : ICreateDto
{
        public int FirmId { get; set; }
        public int AbonentId { get; set; }
        public string ConnectionDate { get; set; }
        public decimal ConnectionCost { get; set; }
        public decimal ForwardingCost { get; set; }
}