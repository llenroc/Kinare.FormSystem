using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using Kinare.FormSystem.Dtos.Forms;
using Kinare.FormSystem.Enums.Forms;
using Kinare.FormSystem.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinare.FormSystem.Dtos.FormRequests
{
    [AutoMap(typeof(FieldAttribute))]
    public class FieldAttributeDto : FullAuditedEntityDto<Guid>
    {
        [Required]
        [StringLength(100)]
        public virtual string Name { get; set; }
        [Required]
        [StringLength(100)]
        public virtual string FieldHeader { get; set; }
        [Required]
        [StringLength(100)]
        public virtual string PlaceHolder { get; set; }
        [Required]
        [StringLength(100)]
        public virtual string HelpText { get; set; }
        [Required]
        [StringLength(100)]
        public virtual string Pattern { get; set; }
        [Required]
        public virtual bool Required { get; set; }
        [Required]
        public virtual FieldAttributeType Type { get; set; }

        public virtual GroupInformationDto GroupInformation { get; set; }

        public virtual ICollection<FieldValueDto> FieldValueList { get; set; }

        public FieldAttributeDto()
        {
            FieldValueList = new HashSet<FieldValueDto>();
        }
    }

}
