namespace ProviderSystemManager.Shared.Dtos.Update;

public class ServiceUpdateDto : IUpdateDto
{
    public int Id { get; set; }
    public int AbonentId { get; set; }
    public double Size { get; set; }
    public string RecievingDate { get; set; }
}