using AutoMapper;
using ProviderSystemManager.BLL.Localization;
using ProviderSystemManager.BLL.Services.Interfaces;
using ProviderSystemManager.DAL.Models;
using ProviderSystemManager.DAL.Repositories.Interfaces;
using ProviderSystemManager.Shared;
using ProviderSystemManager.Shared.Dtos.Create;
using ProviderSystemManager.Shared.Dtos.Get;
using ProviderSystemManager.Shared.Dtos.Update;

namespace ProviderSystemManager.BLL.Services;

public class AbonentService : AbstractService<AbonentCreateDto, AbonentUpdateDto, AbonentGetDto, Abonent>, IAbonentService
{
    private readonly IAbonentTypeRepository _abonentTypeRepository;

    public AbonentService(IMapper mapper, IAbonentRepository repository, IAbonentTypeRepository abonentTypeRepository) :
        base(mapper, repository)
    {
        _abonentTypeRepository = abonentTypeRepository;
    }

    public override async Task<OperationResult<AbonentGetDto>> CreateAsync(params AbonentCreateDto[] dtos)
    {
        var models = Mapper.Map<Abonent[]>(dtos);

        var abonentTypes =  _abonentTypeRepository.GetQuery()
            .Where(x => models.Select(x => x.AbonentTypeId).Contains(x.Id));
        
        foreach (var model in models)
        {
            model.AbonentType = abonentTypes.FirstOrDefault(x => x.Id == model.AbonentTypeId);

            if (model.AbonentType == null)
                return OperationResponse.Bad<AbonentGetDto>(Errors.WrongAbonentType);
        }

        await Repository.Create(models);

        var getDtos = Mapper.Map<AbonentGetDto[]>(models);
        
        return OperationResponse.Ok<AbonentGetDto>(getDtos.First());
    }

    public override async Task<OperationResult<AbonentGetDto>> UpdateAsync(params AbonentUpdateDto[] dtos)
    {
        var models = Mapper.Map<Abonent[]>(dtos);

        var abonentTypes =  _abonentTypeRepository.GetQuery()
            .Where(x => models.Select(x => x.AbonentTypeId).Contains(x.Id));
        
        foreach (var model in models)
        {
            model.AbonentType = abonentTypes.FirstOrDefault(x => x.Id == model.AbonentTypeId);

            if (model.AbonentType == null)
                return OperationResponse.Bad<AbonentGetDto>(Errors.WrongAbonentType);
        }

        await Repository.Update(models);

        var getDtos = Mapper.Map<AbonentGetDto[]>(models);
        
        return OperationResponse.Ok<AbonentGetDto>(getDtos.First());
    }
}