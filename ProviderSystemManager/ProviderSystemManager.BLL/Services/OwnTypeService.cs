using AutoMapper;
using ProviderSystemManager.BLL.Services.Interfaces;
using ProviderSystemManager.DAL.Models;
using ProviderSystemManager.DAL.Repositories.Interfaces;
using ProviderSystemManager.Shared.Dtos.Create;
using ProviderSystemManager.Shared.Dtos.Get;
using ProviderSystemManager.Shared.Dtos.Update;

namespace ProviderSystemManager.BLL.Services;

public class OwnTypeService : AbstractService<OwnTypeCreateDto, OwnTypeUpdateDto, OwnTypeGetDto, OwnType>, IOwnTypeService
{
    public OwnTypeService(IMapper mapper, IOwnTypeRepository repository) : base(mapper, repository) { }
}