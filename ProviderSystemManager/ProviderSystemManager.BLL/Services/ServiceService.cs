using AutoMapper;
using ProviderSystemManager.BLL.Services.Interfaces;
using ProviderSystemManager.DAL.Models;
using ProviderSystemManager.DAL.Repositories.Interfaces;
using ProviderSystemManager.Shared.Dtos.Create;
using ProviderSystemManager.Shared.Dtos.Get;
using ProviderSystemManager.Shared.Dtos.Update;

namespace ProviderSystemManager.BLL.Services;

public class ServiceService : AbstractService<ServiceCreateDto, ServiceUpdateDto, ServiceGetDto, Service>, IServiceService
{
    public ServiceService(IMapper mapper, IServiceRepository repository) : base(mapper, repository)
    {
    }
}