using Abp.AutoMapper;
using Kinare.FormSystem.Sessions.Dto;

namespace Kinare.FormSystem.Web.Models.Account
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}