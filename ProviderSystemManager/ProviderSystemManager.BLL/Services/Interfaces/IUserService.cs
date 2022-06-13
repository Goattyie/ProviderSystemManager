using ProviderSystemManager.Shared.Dtos.Create;
using ProviderSystemManager.Shared.Dtos.Get;
using ProviderSystemManager.Shared;
using ProviderSystemManager.Shared.Dtos.Update;

namespace ProviderSystemManager.BLL.Services.Interfaces;

public interface IUserService : IService<UserCreateDto, UserUpdateDto, UserGetDto>
{
    public Task<OperationResult<UserGetDto>> GetByLoginAsync(string login);
}