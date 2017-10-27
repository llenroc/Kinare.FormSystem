using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Kinare.FormSystem.FormRequests;
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
    [AutoMap(typeof(FieldValue))]
    public class FieldValueDto : EntityDto<Guid>
    {
        [Required]
        public virtual string Value { get; set; }

        public virtual ApplicationFormRequestDto ApplicationFormRequest { get; set; }
        public virtual FieldAttributeDto FieldAttribute { get; set; }
    }
}
