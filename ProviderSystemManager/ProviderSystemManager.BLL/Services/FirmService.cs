using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProviderSystemManager.BLL.Localization;
using ProviderSystemManager.BLL.Services.Interfaces;
using ProviderSystemManager.DAL.Models;
using ProviderSystemManager.DAL.Repositories.Interfaces;
using ProviderSystemManager.Shared;
using ProviderSystemManager.Shared.Dtos.Create;
using ProviderSystemManager.Shared.Dtos.Get;
using ProviderSystemManager.Shared.Dtos.Update;

namespace ProviderSystemManager.BLL.Services;

public class FirmService : AbstractService<FirmCreateDto, FirmUpdateDto, FirmGetDto, Firm>, IFirmService
{
    public static event Action<IEnumerable<FirmGetDto>> OnCreate;
    public static event Action OnUpdate;
    private readonly IOwnTypeRepository _ownTypesRepository;

    public FirmService(IOwnTypeRepository ownTypesRepository, IMapper mapper, IFirmRepository repository)
        : base(mapper, repository)
    {
        _ownTypesRepository = ownTypesRepository;
    }

    public override async Task<OperationResult<FirmGetDto>> CreateAsync(params FirmCreateDto[] dtos)
    {
        var models = Mapper.Map<Firm[]>(dtos);
        var ownTypes = _ownTypesRepository.GetQuery().Where(x => models.Select(m => m.OwnTypeId).Contains(x.Id));

        foreach (var model in models)
        {
            var ownType = await ownTypes.FirstOrDefaultAsync(x => x.Id == model.OwnTypeId);

            if (ownType is null)
                return OperationResponse.Bad<FirmGetDto>(Errors.WrongOwnType);

            model.OwnType = ownType;
        }

        await Repository.Create(models);

        var getDtos = Mapper.Map<IEnumerable<FirmGetDto>>(models);

        OnCreate?.Invoke(getDtos);
        
        return OperationResponse.Ok(getDtos.First());
    }
    
    public override async Task<OperationResult<FirmGetDto>> UpdateAsync(params FirmUpdateDto[] dtos)
    {
        var models = Mapper.Map<Firm[]>(dtos);
        var ownTypes = _ownTypesRepository.GetQuery().Where(x => models.Select(m => m.OwnTypeId).Contains(x.Id));

        foreach (var model in models)
        {
            var ownType = await ownTypes.FirstOrDefaultAsync(x => x.Id == model.OwnTypeId);

            if (ownType is null)
                return OperationResponse.Bad<FirmGetDto>(Errors.WrongOwnType);

            model.OwnType = ownType;
        }

        await Repository.Update(models);

        var getDtos = Mapper.Map<FirmGetDto[]>(models);

        OnUpdate?.Invoke();
        
        return OperationResponse.Ok(getDtos.First());
    }
}