using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Kinare.FormSystem.MultiTenancy.Dto;

namespace Kinare.FormSystem.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
