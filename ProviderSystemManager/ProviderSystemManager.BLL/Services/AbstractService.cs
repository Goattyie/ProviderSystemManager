using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProviderSystemManager.BLL.Services.Interfaces;
using ProviderSystemManager.DAL.Models;
using ProviderSystemManager.DAL.Repositories.Interfaces;
using ProviderSystemManager.Shared;
using ProviderSystemManager.Shared.Dtos.Create;
using ProviderSystemManager.Shared.Dtos.Get;
using ProviderSystemManager.Shared.Dtos.Update;

namespace ProviderSystemManager.BLL.Services;

public abstract class AbstractService<TCreateDto, TUpdateDto, TGetDto, TModel> : IService<TCreateDto, TUpdateDto, TGetDto>
    where TCreateDto : ICreateDto
    where TUpdateDto : IUpdateDto
    where TGetDto : IGetDto
    where TModel: BaseModel
{

    public static event Action<IEnumerable<TGetDto>> OnCreate;
    public AbstractService(IMapper mapper, IRepository<TModel> repository)
    {
        Mapper = mapper;
        Repository = repository;
    }

    protected IRepository<TModel> Repository { get; }
    protected IMapper Mapper { get; }
    public virtual async Task<OperationResult<IEnumerable<TGetDto>>> GetAsync()
    {
        var models = await Repository.GetAsync();
        var dtos = Mapper.Map<IEnumerable<TGetDto>>(models);
        
        return OperationResponse.Ok(dtos);
    }

    public virtual OperationResult<IEnumerable<TGetDto>> Get()
    {
        var models = Repository.Get();
        var dtos = Mapper.Map<IEnumerable<TGetDto>>(models);

        return OperationResponse.Ok(dtos);
    }

    public async Task<OperationResult<TGetDto>> GetByIdAsync(int id)
    {
        var model = await Repository.GetById(id);
        var dto = Mapper.Map<TGetDto>(model);
        
        return OperationResponse.Ok(dto);
    }

    public virtual async Task<OperationResult<TGetDto>> CreateAsync(params TCreateDto[] dtos)
    {
        var models = Mapper.Map<TModel[]>(dtos);

        await Repository.Create(models);

        var getDtos = Mapper.Map<IEnumerable<TGetDto>>(models);

        OnCreate?.Invoke(getDtos);

        return OperationResponse.Ok(getDtos.First());

    }

    public virtual async Task<OperationResult<TGetDto>> UpdateAsync(params TUpdateDto[] dtos)
    {
        var models = Mapper.Map<TModel[]>(dtos);

        await Repository.Update(models);

        var getDtos =  Mapper.Map<IEnumerable<TGetDto>>(models);

        return OperationResponse.Ok(getDtos.First());
    }

    public virtual async Task<OperationResult<TGetDto>> RemoveAsync(params int[] ids)
    {
        var models = await Repository.GetQuery().Where(x => ids.Contains(x.Id)).ToArrayAsync();
        
        await Repository.Remove(models);

        return OperationResponse.Ok<TGetDto>();
    }
}