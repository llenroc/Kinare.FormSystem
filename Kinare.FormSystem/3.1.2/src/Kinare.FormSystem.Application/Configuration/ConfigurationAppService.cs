using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Kinare.FormSystem.Configuration.Dto;

namespace Kinare.FormSystem.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : FormSystemAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
