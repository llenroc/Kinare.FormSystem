using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Kinare.FormSystem.FormRequests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinare.FormSystem.Forms
{
    [Table("FieldValue")]
    public class FieldValue : Entity<Guid>
    {
        public Guid ApplicationFormRequestId { get; set; }
        public Guid FieldAttributeId { get; set; }

        [Required]
        public virtual string Value { get; set; }

        public virtual ApplicationFormRequest ApplicationFormRequest { get; set; }
        public virtual FieldAttribute FieldAttribute { get; set; }
    }
}
