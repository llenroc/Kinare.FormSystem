using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Kinare.FormSystem.Dtos.Forms;
using Kinare.FormSystem.Forms;
using Kinare.FormSystem.Repositories.Forms;
using System;
using System.Threading.Tasks;

namespace Kinare.FormSystem.Services.Forms
{
    public class ApplicationFormService : AsyncCrudAppService<ApplicationForm, ApplicationFormDto, Guid, PagedResultRequestDto, ApplicationFormDto, ApplicationFormDto>, IApplicationFormService
    {
        private readonly IApplicationFormRepository repository;

        protected ApplicationFormService(IApplicationFormRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        public override async Task<ApplicationFormDto> Create(ApplicationFormDto input)
        {
            var entity = AutoMapper.Mapper.Map<ApplicationForm>(input);
            entity = await repository.InsertAsync(entity);
            return AutoMapper.Mapper.Map<ApplicationFormDto>(entity);
        }

        public override async Task Delete(EntityDto<Guid> input)
        {
            var entity = AutoMapper.Mapper.Map<ApplicationForm>(input);

            entity.IsDeleted = false;

            entity = await repository.UpdateAsync(entity);
        }

        public override async Task<ApplicationFormDto> Update(ApplicationFormDto input)
        {
            var entity = AutoMapper.Mapper.Map<ApplicationForm>(input);

            entity.IsDeleted = false;

            entity = await repository.UpdateAsync(entity);

            return AutoMapper.Mapper.Map<ApplicationFormDto>(entity);
        }
    }
}
