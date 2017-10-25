using Kinare.FormSystem.EntityFramework;
using EntityFramework.DynamicFilters;

namespace Kinare.FormSystem.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly FormSystemDbContext _context;

        public InitialHostDbBuilder(FormSystemDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
