using ProviderSystemManager.Shared.Dtos.Create;
using ProviderSystemManager.Shared.Dtos.Get;
using ProviderSystemManager.Shared.Dtos.Update;

namespace ProviderSystemManager.BLL.Services.Interfaces;


public interface IFirmService : IService<FirmCreateDto, FirmUpdateDto, FirmGetDto>
{
    
}