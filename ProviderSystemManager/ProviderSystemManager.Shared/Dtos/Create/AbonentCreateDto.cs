namespace ProviderSystemManager.Shared.Dtos.Create;

public class AbonentCreateDto : ICreateDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public int AbonentTypeId { get; set; }
}