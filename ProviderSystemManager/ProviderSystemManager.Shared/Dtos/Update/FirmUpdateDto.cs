namespace ProviderSystemManager.Shared.Dtos.Update;

public class FirmUpdateDto : IUpdateDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Telephone { get; set; }
    public string Address { get; set; }
    public short StartWorkingYear{ get; set; }
    public int OwnTypeId { get; set; }
}