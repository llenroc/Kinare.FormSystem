using Abp.Domain.Entities.Auditing;
using Kinare.FormSystem.Forms;
using Kinare.FormSystem.Repositories.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.EntityFramework;

namespace Kinare.FormSystem.EntityFramework.Repositories.Forms
{

    public class ApplicationFormRepository : FormSystemRepositoryBase<ApplicationForm, Guid>, IApplicationFormRepository
    {
        protected ApplicationFormRepository(IDbContextProvider<FormSystemDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
