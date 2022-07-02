using ProviderSystemManager.Shared.Dtos.Create;
using ProviderSystemManager.Shared.Dtos.Get;
using ProviderSystemManager.Shared.Dtos.Update;
using ProviderSystemManager.Shared;

namespace ProviderSystemManager.BLL.Services.Interfaces;


public interface IService<TCreateDto, TUpdateDto, TGetDto>
    where TCreateDto : ICreateDto
    where TUpdateDto : IUpdateDto
    where TGetDto : IGetDto
{
    public Task<OperationResult<IEnumerable<TGetDto>>> GetAsync();
    public OperationResult<IEnumerable<TGetDto>> Get();
    public Task<OperationResult<TGetDto>> GetByIdAsync(int id);
    public OperationResult<TGetDto> GetById(int id);
    public Task<OperationResult<TGetDto>> CreateAsync(params TCreateDto[] dtos);
    public Task<OperationResult<TGetDto>> UpdateAsync(params TUpdateDto[] dtos);
    public Task<OperationResult<TGetDto>> RemoveAsync(params int[] ids);
}