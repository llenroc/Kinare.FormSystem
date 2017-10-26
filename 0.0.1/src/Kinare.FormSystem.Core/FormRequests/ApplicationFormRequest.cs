using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Kinare.FormSystem.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kinare.FormSystem.FormRequests
{
    [Table("ApplicationFormRequest")]
    public class ApplicationFormRequest : Entity<Guid>, IHasCreationTime
    {
        public Guid ApplicationFormId { get; set; }
        public Guid BrowserInformationId { get; set; }
        public Guid WindowInformationId { get; set; }

        [Required]
        public virtual DateTime CreationTime { get; set; }
        [Required]
        public virtual int Progress { get; set; }

        public virtual ApplicationForm ApplicationForm { get; set; }

        public virtual BrowserInformation BrowserInformation { get; set; }
        public virtual WindowInformation WindowInformation { get; set; }
        public virtual ICollection<ParameterRequest> ParameterRequestList { get; set; }

        public virtual ICollection<FieldValue> FieldValueList { get; set; }

        public ApplicationFormRequest()
        {
            ParameterRequestList = new HashSet<ParameterRequest>();
            FieldValueList = new HashSet<FieldValue>();
        }
    }
}
