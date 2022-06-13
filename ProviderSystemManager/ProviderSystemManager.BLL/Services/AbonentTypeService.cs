using AutoMapper;
using ProviderSystemManager.BLL.Services.Interfaces;
using ProviderSystemManager.DAL.Models;
using ProviderSystemManager.DAL.Repositories.Interfaces;
using ProviderSystemManager.Shared.Dtos.Create;
using ProviderSystemManager.Shared.Dtos.Get;
using ProviderSystemManager.Shared.Dtos.Update;

namespace ProviderSystemManager.BLL.Services;

public class AbonentTypeService : AbstractService<AbonentTypeCreateDto, AbonentTypeUpdateDto, AbonentTypeGetDto, AbonentType>, IAbonentTypeService
{
    public AbonentTypeService(IMapper mapper, IAbonentTypeRepository repository) : base(mapper, repository) { }
}