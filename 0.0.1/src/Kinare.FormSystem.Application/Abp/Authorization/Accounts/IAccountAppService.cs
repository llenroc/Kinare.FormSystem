using System.Threading.Tasks;
using Abp.Application.Services;
using Kinare.FormSystem.Authorization.Accounts.Dto;

namespace Kinare.FormSystem.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
