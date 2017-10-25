using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Kinare.FormSystem.MultiTenancy;

namespace Kinare.FormSystem.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}