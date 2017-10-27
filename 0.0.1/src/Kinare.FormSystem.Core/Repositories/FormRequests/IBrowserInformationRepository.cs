using Abp.Domain.Repositories;
using Kinare.FormSystem.FormRequests;
using System;

namespace Kinare.FormSystem.Repositories.FormRequests
{
    public interface IBrowserInformationRepository : IRepository<BrowserInformation, Guid>
    {
    }
}