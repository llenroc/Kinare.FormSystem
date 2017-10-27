using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinare.FormSystem.Forms
{
    [Table("GroupInformation")]
    public class GroupInformation : FullAuditedEntity<Guid>
    {
        public Guid ApplicationFormId { get; set; }

        [Required]
        [StringLength(100)]
        public virtual string Name { get; set; }
        [Required]
        [StringLength(100)]
        public virtual string Header { get; set; }
        [Required]
        public virtual int Order { get; set; }

        public virtual ApplicationForm ApplicationForm { get; set; }

        public virtual ICollection<FieldAttribute> FieldAttributeList { get; set; }

        public GroupInformation()
        {
            FieldAttributeList = new HashSet<FieldAttribute>();
        }
    }
}
