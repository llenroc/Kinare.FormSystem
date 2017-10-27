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

namespace Kinare.FormSystem.Dtos.FormRequests
{
    [AutoMap(typeof(ApplicationFormRequest))]
    public class ApplicationFormRequestDto : EntityDto<Guid>, IHasCreationTime
    {
        [Required]
        public virtual DateTime CreationTime { get; set; }
        [Required]
        public virtual int Progress { get; set; }

        public virtual ApplicationForm ApplicationForm { get; set; }

        public virtual BrowserInformationDto BrowserInformation { get; set; }
        public virtual WindowInformationDto WindowInformation { get; set; }
        public virtual ICollection<ParameterRequestDto> ParameterRequestList { get; set; }

        //public virtual ICollection<FieldValue> FieldValueList { get; set; }

        public ApplicationFormRequestDto()
        {
            ParameterRequestList = new HashSet<ParameterRequestDto>();
            //FieldValueList = new HashSet<FieldValue>();
        }
    }
}
