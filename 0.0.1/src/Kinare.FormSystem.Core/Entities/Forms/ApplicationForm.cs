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
    [Table("ApplicationForm")]
    public class ApplicationForm : AuditedEntity<Guid>
    {
        [Required]
        [StringLength(100)]
        public virtual string Name { get; set; }
        [Required]
        [StringLength(100)]
        public virtual string Header { get; set; }

        public virtual ICollection<GroupInformation> GroupInformationList { get; set; }

        public virtual ICollection<ApplicationFormRequest> ApplicationFormRequestList { get; set; }

        public ApplicationForm()
        {
            GroupInformationList = new HashSet<GroupInformation>();
            ApplicationFormRequestList = new HashSet<ApplicationFormRequest>();
        }
    }
}
