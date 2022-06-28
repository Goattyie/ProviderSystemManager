namespace ProviderSystemManager.BLL.Exporters.Interfaces
{
    public interface IExporter <T>
    {
        Task<Stream> Export(T data);
    }
}
