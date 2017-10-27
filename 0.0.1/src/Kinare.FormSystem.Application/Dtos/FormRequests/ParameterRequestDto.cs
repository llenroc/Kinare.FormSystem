using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using Kinare.FormSystem.FormRequests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinare.FormSystem.Dtos.FormRequests
{
    [AutoMap(typeof(ParameterRequest))]
    public class ParameterRequestDto : EntityDto<Guid>
    {
        [Required]
        public virtual string Name { get; set; }
        [Required]
        public virtual string Value { get; set; }

        public virtual ApplicationFormRequestDto ApplicationFormRequest { get; set; }
    }
}
