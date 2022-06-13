using AutoMapper;
using ProviderSystemManager.BLL.Localization;
using ProviderSystemManager.BLL.Services.Interfaces;
using ProviderSystemManager.DAL.Models;
using ProviderSystemManager.DAL.Repositories.Interfaces;
using ProviderSystemManager.Shared;
using ProviderSystemManager.Shared.Dtos.Create;
using ProviderSystemManager.Shared.Dtos.Get;
using ProviderSystemManager.Shared.Dtos.Update;
using System.Security.Cryptography;

namespace ProviderSystemManager.BLL.Services;

public class UserService : AbstractService<UserCreateDto, UserUpdateDto, UserGetDto, User>, IUserService
{
    public UserService(IMapper mapper, IUserRepository repository) : base(mapper, repository)
    {
    }

    public Task<OperationResult<UserGetDto>> GetByLoginAsync(string login)
    {
        var model = Repository.GetQuery().FirstOrDefault(x => x.Login == login);

        if (model is null)
            return Task.FromResult(OperationResponse.Bad<UserGetDto>(Errors.WrongLogin));

        var dto = Mapper.Map<UserGetDto>(model);

        return Task.FromResult(OperationResponse.Ok(dto));
    }
}