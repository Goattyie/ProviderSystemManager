namespace ProviderSystemManager.Shared.Dtos.Create;

public class UserCreateDto : ICreateDto
{
    public string Login { get; set; }
    public string Password { get; set; }
    public int Role { get; set; }
}