using System.Threading.Tasks;
using Abp.Application.Services;
using Kinare.FormSystem.Configuration.Dto;

namespace Kinare.FormSystem.Configuration
{
    public interface IConfigurationAppService: IApplicationService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}