namespace ProviderSystemManager.Shared.Dtos.Get;

public class FirmGetDto : IGetDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Telephone { get; set; }
    public string Address { get; set; }
    public short StartWorkingYear{ get; set; }
    public OwnTypeGetDto OwnType { get; set; }
}