namespace ProviderSystemManager.Shared.Dtos.Update;

public class AbonentUpdateDto : IUpdateDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public int AbonentTypeId { get; set; }
}