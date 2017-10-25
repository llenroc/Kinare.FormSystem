using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace Kinare.FormSystem.EntityFramework.Repositories
{
    public abstract class FormSystemRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<FormSystemDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected FormSystemRepositoryBase(IDbContextProvider<FormSystemDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class FormSystemRepositoryBase<TEntity> : FormSystemRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected FormSystemRepositoryBase(IDbContextProvider<FormSystemDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
