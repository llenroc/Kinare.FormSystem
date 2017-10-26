namespace Kinare.FormSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationFormRequest_AddProgressField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationFormRequest", "Progress", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicationFormRequest", "Progress");
        }
    }
}
