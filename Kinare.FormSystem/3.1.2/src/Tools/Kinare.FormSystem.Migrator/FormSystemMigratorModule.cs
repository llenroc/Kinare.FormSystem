using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Kinare.FormSystem.EntityFramework;

namespace Kinare.FormSystem.Migrator
{
    [DependsOn(typeof(FormSystemDataModule))]
    public class FormSystemMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<FormSystemDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}