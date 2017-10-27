using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using Kinare.FormSystem.Dtos.FormRequests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinare.FormSystem.Dtos.Forms
{
    [AutoMap(typeof(GroupInformationDto))]
    public class GroupInformationDto : FullAuditedEntityDto<Guid>
    {
        [Required]
        [StringLength(100)]
        public virtual string Name { get; set; }
        [Required]
        [StringLength(100)]
        public virtual string Header { get; set; }
        [Required]
        public virtual int Order { get; set; }

        public virtual ApplicationFormDto ApplicationForm { get; set; }

        public virtual ICollection<FieldAttributeDto> FieldAttributeList { get; set; }

        public GroupInformationDto()
        {
            FieldAttributeList = new HashSet<FieldAttributeDto>();
        }
    }
}
