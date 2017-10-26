using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinare.FormSystem.EntityFramework.Mappings
{
    public class FormSystemMappingBase<TEntity> : EntityTypeConfiguration<TEntity>
        where TEntity : AuditedEntity<Guid>
    {
        public FormSystemMappingBase(string tableName)
        {
            this.ToTable(tableName);
        }
    }

}
