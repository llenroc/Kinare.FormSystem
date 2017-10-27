using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Kinare.FormSystem.Dtos.Forms;
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
    public class GroupInformationService : AsyncCrudAppService<GroupInformation, GroupInformationDto, Guid, PagedResultRequestDto, GroupInformationDto, GroupInformationDto>, IGroupInformationService
    {
        private readonly IGroupInformationRepository repository;
        protected GroupInformationService(IGroupInformationRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
