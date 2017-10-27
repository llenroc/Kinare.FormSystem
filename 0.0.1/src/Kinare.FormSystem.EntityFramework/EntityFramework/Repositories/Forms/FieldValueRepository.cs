using Kinare.FormSystem.Forms;
using Kinare.FormSystem.Repositories.Forms;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.EntityFramework;

namespace Kinare.FormSystem.EntityFramework.Repositories.Forms
{
    public class FieldValueRepository : FormSystemRepositoryBase<FieldValue, Guid>, IFieldValueRepository
    {
        protected FieldValueRepository(IDbContextProvider<FormSystemDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
