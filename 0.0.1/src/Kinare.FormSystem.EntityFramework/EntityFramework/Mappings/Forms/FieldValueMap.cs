using Kinare.FormSystem.Forms;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinare.FormSystem.EntityFramework.Mappings.Forms
{
    class FieldValueMap : EntityTypeConfiguration<FieldValue>
    {
        const string tableName = "FieldValue";

        public FieldValueMap() 
        {
            this.ToTable(tableName);
        }
    }
}
