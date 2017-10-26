using Abp.Domain.Entities.Auditing;
using Kinare.FormSystem.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinare.FormSystem.EntityFramework.Mappings.Forms
{

    public class ApplicationFormMap : FormSystemMappingBase<ApplicationForm>
    {
        const string tableName = "ApplicationForm";

        public ApplicationFormMap() : base(tableName)
        {
            this.HasMany(e => e.GroupInformationList)
               .WithRequired(e => e.ApplicationForm)
               .WillCascadeOnDelete(false);

            this.HasMany(e => e.ApplicationFormRequestList)
               .WithRequired(e => e.ApplicationForm)
               .WillCascadeOnDelete(false);
        }
    }
}
