namespace ProviderSystemManager.Shared.Dtos.Create;

public class ServiceCreateDto : ICreateDto
{
    public int AbonentId { get; set; }
    public double Size { get; set; }
    public string RecievingDate { get; set; }
}