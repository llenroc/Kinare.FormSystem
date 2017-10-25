using System.Threading.Tasks;
using Abp.Application.Services;
using Kinare.FormSystem.Sessions.Dto;

namespace Kinare.FormSystem.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
