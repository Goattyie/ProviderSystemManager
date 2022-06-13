namespace ProviderSystemManager.Shared.Dtos.Get;

public class AbonentGetDto : IGetDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public AbonentTypeGetDto AbonentType { get; set; }
}