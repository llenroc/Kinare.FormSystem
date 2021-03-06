﻿using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Kinare.FormSystem.FormRequests;
using Kinare.FormSystem.Forms;
using Kinare.FormSystem.Repositories.FormRequests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Abp.EntityFramework;

namespace Kinare.FormSystem.EntityFramework.Repositories.FormRequests
{
    public class ApplicationFormRequestRepository : FormSystemRepositoryBase<ApplicationFormRequest, Guid>, IApplicationFormRequestRepository
    {
        protected ApplicationFormRequestRepository(IDbContextProvider<FormSystemDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
