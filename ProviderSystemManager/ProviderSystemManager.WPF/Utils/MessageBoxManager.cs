using System.Windows;

namespace ProviderSystemManager.WPF.Utils
{
    internal static class MessageBoxManager
    {
        public static MessageBoxResult ShowError(string error) => MessageBox.Show(error, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        public static MessageBoxResult ShowSuccess(string msg) => MessageBox.Show(msg, "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
    }
}
