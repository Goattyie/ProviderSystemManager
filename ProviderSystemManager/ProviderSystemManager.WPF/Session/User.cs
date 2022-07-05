using ProviderSystemManager.DAL.Enums;

namespace ProviderSystemManager.WPF.Session
{
    internal static class User
    {
        public static int Id { get; set; }
        public static string Login { get; set; }
        public static string Password { get; set; }
        public static UserRole Role { get; set; }
    }
}
