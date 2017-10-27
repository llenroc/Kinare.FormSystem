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
    public class FieldAttributeService : AsyncCrudAppService<FieldAttribute, FieldAttributeDto, Guid, PagedResultRequestDto, FieldAttributeDto, FieldAttributeDto>, IFieldAttributeService
    {
        private readonly IFieldAttributeRepository repository;

        protected FieldAttributeService(IFieldAttributeRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
