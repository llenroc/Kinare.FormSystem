using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Kinare.FormSystem.Dtos.Forms;
using Kinare.FormSystem.Forms;
using System;

namespace Kinare.FormSystem.Services.Forms
{
    public interface IGroupInformationService : IAsyncCrudAppService<GroupInformationDto, Guid, PagedResultRequestDto, GroupInformationDto, GroupInformationDto>
    {
    }
}
