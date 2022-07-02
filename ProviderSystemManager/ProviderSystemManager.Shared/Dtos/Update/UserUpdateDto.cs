using ProviderSystemManager.DAL.Enums;

namespace ProviderSystemManager.Shared.Dtos.Update
{
    public class UserUpdateDto : IUpdateDto
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }

    }
}
