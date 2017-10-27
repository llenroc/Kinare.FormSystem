using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Kinare.FormSystem.Dtos.FormRequests;
using Kinare.FormSystem.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Kinare.FormSystem.Repositories.Forms;

namespace Kinare.FormSystem.Services.Forms
{
    public class FieldValueService : AsyncCrudAppService<FieldValue, FieldValueDto, Guid, PagedResultRequestDto, FieldValueDto, FieldValueDto>, IFieldValueService
    {
        private readonly IFieldValueRepository repository;

        protected FieldValueService(IFieldValueRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
