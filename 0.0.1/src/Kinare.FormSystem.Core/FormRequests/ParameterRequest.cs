using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinare.FormSystem.FormRequests
{
    [Table("ParameterRequest")]
    public class ParameterRequest : Entity<Guid>
    {
        public Guid ApplicationFormRequestId { get; set; }

        [Required]
        public virtual string Name { get; set; }
        [Required]
        public virtual string Value { get; set; }

        public virtual ApplicationFormRequest ApplicationFormRequest { get; set; }
    }
}
