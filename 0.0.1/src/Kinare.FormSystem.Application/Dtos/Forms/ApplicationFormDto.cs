using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using Kinare.FormSystem.Dtos.FormRequests;
using Kinare.FormSystem.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kinare.FormSystem.Dtos.Forms
{
    [AutoMap(typeof(ApplicationForm))]
    public class ApplicationFormDto : FullAuditedEntityDto<Guid>
    {
        [Required]
        [StringLength(100)]
        public virtual string Name { get; set; }
        [Required]
        [StringLength(100)]
        public virtual string Header { get; set; }

        public virtual ICollection<GroupInformationDto> GroupInformationList { get; set; }

        public virtual ICollection<ApplicationFormRequestDto> ApplicationFormRequestList { get; set; }

        public ApplicationFormDto()
        {
            GroupInformationList = new HashSet<GroupInformationDto>();
            ApplicationFormRequestList = new HashSet<ApplicationFormRequestDto>();
        }
    }
}
