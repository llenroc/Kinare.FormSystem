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
    public class GroupInformationMap : FormSystemMappingBase<GroupInformation>
    {
        const string tableName = "GroupInformation";

        public GroupInformationMap() : base(tableName)
        {
            this.HasMany(e => e.FieldAttributeList)
               .WithRequired(e => e.GroupInformation)
               .WillCascadeOnDelete(false);
        }
    }
}
