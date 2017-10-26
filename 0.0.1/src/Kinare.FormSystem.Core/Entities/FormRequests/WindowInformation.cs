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
    [Table("WindowInformation")]
    public class WindowInformation : Entity<Guid>
    {
        public Guid ApplicationFormRequestId { get; set; }

        [Required]
        public virtual int Width { get; set; }
        [Required]
        public virtual int Height { get; set; }

        public virtual ApplicationFormRequest ApplicationFormRequest { get; set; }
    }
}
