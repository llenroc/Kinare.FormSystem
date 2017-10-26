using Abp.Domain.Entities.Auditing;
using Kinare.FormSystem.Enums.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinare.FormSystem.Forms
{
    [Table("FieldAttribute")]
    public class FieldAttribute : AuditedEntity<Guid>
    {
        public Guid GroupInformationId { get; set; }

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

        public virtual GroupInformation GroupInformation { get; set; }

        public virtual ICollection<FieldValue> FieldValueList { get; set; }

        public FieldAttribute()
        {
            FieldValueList = new HashSet<FieldValue>();
        }
    }

}
