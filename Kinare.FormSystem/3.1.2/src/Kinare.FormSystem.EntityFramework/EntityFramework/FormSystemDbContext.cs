using System.Data.Common;
using Abp.Zero.EntityFramework;
using Kinare.FormSystem.Authorization.Roles;
using Kinare.FormSystem.Authorization.Users;
using Kinare.FormSystem.MultiTenancy;

namespace Kinare.FormSystem.EntityFramework
{
    public class FormSystemDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public FormSystemDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in FormSystemDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of FormSystemDbContext since ABP automatically handles it.
         */
        public FormSystemDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public FormSystemDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public FormSystemDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }
    }
}
