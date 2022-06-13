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

public class ContractService : AbstractService<ContractCreateDto, ContractUpdateDto, ContractGetDto, Contract>, IContractService
{
    private readonly IAbonentRepository _abonentRepository;
    private readonly IFirmRepository _firmRepository;

    public ContractService(IFirmRepository firmRepository, IAbonentRepository abonentRepository, IMapper mapper, IContractRepository repository) : base(mapper, repository)
    {
        _firmRepository = firmRepository;
        _abonentRepository = abonentRepository;
    }

    public override async Task<OperationResult<ContractGetDto>> CreateAsync(params ContractCreateDto[] dtos)
    {
        var models = Mapper.Map<Contract[]>(dtos);
        var firms = _firmRepository.GetQuery().Where(x => models.Select(m => m.FirmId).Contains(x.Id));
        var abonents = _abonentRepository.GetQuery().Where(x => models.Select(m => m.AbonentId).Contains(x.Id));

        foreach (var model in models)
        {
            var firm = await firms.FirstOrDefaultAsync(x => x.Id == model.FirmId);

            if (firm is null)
                return OperationResponse.Bad<ContractGetDto>(Errors.WrongFirm);
            
            var abonent = await abonents.FirstOrDefaultAsync(x => x.Id == model.AbonentId);

            if (abonent is null)
                return OperationResponse.Bad<ContractGetDto>(Errors.WrongAbonent);

            model.Firm = firm;
            model.Abonent = abonent;
        }

        await Repository.Create(models);

        var getDtos = Mapper.Map<ContractGetDto[]>(models);
        
        return OperationResponse.Ok(getDtos.First());
    }
    
    public override async Task<OperationResult<ContractGetDto>> UpdateAsync(params ContractUpdateDto[] dtos)
    {
        var models = Mapper.Map<Contract[]>(dtos);
        var firms = _firmRepository.GetQuery().Where(x => models.Select(m => m.FirmId).Contains(x.Id));
        var abonents = _abonentRepository.GetQuery().Where(x => models.Select(m => m.AbonentId).Contains(x.Id));

        foreach (var model in models)
        {
            var firm = await firms.FirstOrDefaultAsync(x => x.Id == model.FirmId);

            if (firm is null)
                return OperationResponse.Bad<ContractGetDto>(Errors.WrongFirm);

            var abonent = await abonents.FirstOrDefaultAsync(x => x.Id == model.AbonentId);

            if (abonent is null)
                return OperationResponse.Bad<ContractGetDto>(Errors.WrongAbonent);

            model.Firm = firm;
            model.Abonent = abonent;
        }

        await Repository.Update(models);

        var getDtos = Mapper.Map<ContractGetDto[]>(models);
        
        return OperationResponse.Ok(getDtos.First());
    }
}