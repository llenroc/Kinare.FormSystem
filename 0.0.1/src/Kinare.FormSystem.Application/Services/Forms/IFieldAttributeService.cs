using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Kinare.FormSystem.Dtos.FormRequests;
using Kinare.FormSystem.Forms;
using System;

namespace Kinare.FormSystem.Services.Forms
{
    public interface IFieldAttributeService : IAsyncCrudAppService<FieldAttributeDto, Guid, PagedResultRequestDto, FieldAttributeDto, FieldAttributeDto>
    {
    }
}