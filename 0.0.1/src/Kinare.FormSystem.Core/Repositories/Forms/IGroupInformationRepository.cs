﻿using Abp.Domain.Repositories;
using Kinare.FormSystem.Forms;
using System;

namespace Kinare.FormSystem.Repositories.Forms
{
    public interface IGroupInformationRepository : IRepository<GroupInformation, Guid>
    {
    }
}
