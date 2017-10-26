using System.Data.Common;
using Abp.Zero.EntityFramework;
using Kinare.FormSystem.Authorization.Roles;
using Kinare.FormSystem.Authorization.Users;
using Kinare.FormSystem.MultiTenancy;
using System.Data.Entity;
using Kinare.FormSystem.Forms;
using Kinare.FormSystem.FormRequests;

namespace Kinare.FormSystem.EntityFramework
{
    public class FormSystemDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...
        public virtual IDbSet<ApplicationForm> ApplicationFormList { get; set; }
        public virtual IDbSet<GroupInformation> GroupInformationList { get; set; }
        public virtual IDbSet<FieldAttribute> FieldAttributeList { get; set; }

        public virtual IDbSet<ApplicationFormRequest> ApplicationFormRequestList { get; set; }
        public virtual IDbSet<BrowserInformation> BrowserInformationList { get; set; }
        public virtual IDbSet<WindowInformation> WindowInformationList { get; set; }
        public virtual IDbSet<ParameterRequest> ParameterRequestList { get; set; }

        public virtual IDbSet<FieldValue> FieldValueList { get; set; }


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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Map
            modelBuilder.Configurations.Add(new Mappings.Forms.ApplicationFormMap());
            modelBuilder.Configurations.Add(new Mappings.Forms.GroupInformationMap());
            modelBuilder.Configurations.Add(new Mappings.Forms.FieldAttributeMap());

            modelBuilder.Configurations.Add(new Mappings.FormRequests.ApplicationFormRequestMap());
            modelBuilder.Configurations.Add(new Mappings.FormRequests.BrowserInformationMap());
            modelBuilder.Configurations.Add(new Mappings.FormRequests.WindowInformationMap());
            modelBuilder.Configurations.Add(new Mappings.FormRequests.ParameterRequestMap());

            modelBuilder.Configurations.Add(new Mappings.Forms.FieldValueMap());
        }
    }
}
