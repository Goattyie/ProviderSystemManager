namespace ProviderSystemManager.DAL.Queries.Interfaces
{
    public record AbonentInfoModel(string AbonentName, string AbonentType);
    public interface IAbonentInfoQuery: IQuery<IEnumerable<AbonentInfoModel>>
    {
    }
}
