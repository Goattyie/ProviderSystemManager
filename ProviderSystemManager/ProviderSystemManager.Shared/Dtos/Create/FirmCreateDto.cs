namespace ProviderSystemManager.Shared.Dtos.Create;

public class FirmCreateDto : ICreateDto
{
    public string Name { get; set; }
    public string Telephone { get; set; }
    public string Address { get; set; }
    public short StartWorkingYear{ get; set; }
    public int OwnTypeId { get; set; }
}