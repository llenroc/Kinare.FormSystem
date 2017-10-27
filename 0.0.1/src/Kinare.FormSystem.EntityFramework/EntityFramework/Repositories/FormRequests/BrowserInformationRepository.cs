using Abp.Domain.Entities;
using Kinare.FormSystem.FormRequests;
using Kinare.FormSystem.Repositories.FormRequests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.EntityFramework;

namespace Kinare.FormSystem.EntityFramework.Repositories.FormRequests
{
    public class BrowserInformationRepository : FormSystemRepositoryBase<BrowserInformation, Guid>, IBrowserInformationRepository
    {
        protected BrowserInformationRepository(IDbContextProvider<FormSystemDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
