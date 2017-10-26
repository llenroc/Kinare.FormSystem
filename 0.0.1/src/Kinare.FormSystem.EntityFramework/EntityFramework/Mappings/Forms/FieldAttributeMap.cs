using Abp.Domain.Entities.Auditing;
using Kinare.FormSystem.Enums.Forms;
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
    public class FieldAttributeMap : FormSystemMappingBase<FieldAttribute>
    {
        const string tableName = "FieldAttribute";

        public FieldAttributeMap() : base(tableName)
        {
            this.HasMany(e => e.FieldValueList)
               .WithRequired(e => e.FieldAttribute)
               .WillCascadeOnDelete(false);
        }
    }
}
