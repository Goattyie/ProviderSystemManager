using ProviderSystemManager.Shared;
using ProviderSystemManager.Shared.Dtos.Create;
using ProviderSystemManager.Shared.Dtos.Get;
using ProviderSystemManager.Shared.Dtos.Update;

namespace ProviderSystemManager.BLL.Services.Interfaces;


public interface IContractService : IService<ContractCreateDto, ContractUpdateDto, ContractGetDto>
{
    OperationResult<IEnumerable<ContractGetDto>> GetByFirmId(int firmId);
}