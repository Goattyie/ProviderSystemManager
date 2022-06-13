namespace ProviderSystemManager.Shared.Dtos.Get;

public class UserGetDto : IGetDto
{
    public string Login { get; set; }
    public string Password { get; set; }
    public string UserRole { get; set; }
    public int Id { get; set; }
}