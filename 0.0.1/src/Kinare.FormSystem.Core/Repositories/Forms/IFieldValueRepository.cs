using Abp.Domain.Repositories;
using Kinare.FormSystem.Forms;
using System;

namespace Kinare.FormSystem.Repositories.Forms
{
    public interface IFieldValueRepository : IRepository<FieldValue, Guid>
    {
    }
}