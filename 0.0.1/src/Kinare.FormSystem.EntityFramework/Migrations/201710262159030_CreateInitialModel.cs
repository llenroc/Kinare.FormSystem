namespace Kinare.FormSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class _CreateInitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationForm",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    Name = c.String(nullable: false, maxLength: 100),
                    Header = c.String(nullable: false, maxLength: 100),
                    LastModificationTime = c.DateTime(),
                    LastModifierUserId = c.Long(),
                    CreationTime = c.DateTime(nullable: false),
                    CreatorUserId = c.Long(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.ApplicationFormRequest",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    ApplicationFormId = c.Guid(nullable: false),
                    BrowserInformationId = c.Guid(nullable: false),
                    WindowInformationId = c.Guid(nullable: false),
                    CreationTime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationForm", t => t.ApplicationFormId)
                .Index(t => t.ApplicationFormId);

            CreateTable(
                "dbo.BrowserInformation",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    ApplicationFormRequestId = c.Guid(nullable: false),
                    PreviousUrl = c.String(nullable: false),
                    Platform = c.String(nullable: false),
                    Name = c.String(nullable: false),
                    Version = c.String(nullable: false),
                    UserAgent = c.String(nullable: false),
                    Vendor = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationFormRequest", t => t.Id)
                .Index(t => t.Id);

            CreateTable(
                "dbo.FieldValue",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    ApplicationFormRequestId = c.Guid(nullable: false),
                    FieldAttributeId = c.Guid(nullable: false),
                    Value = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FieldAttribute", t => t.FieldAttributeId)
                .ForeignKey("dbo.ApplicationFormRequest", t => t.ApplicationFormRequestId)
                .Index(t => t.ApplicationFormRequestId)
                .Index(t => t.FieldAttributeId);

            CreateTable(
                "dbo.FieldAttribute",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    GroupInformationId = c.Guid(nullable: false),
                    Name = c.String(nullable: false, maxLength: 100),
                    FieldHeader = c.String(nullable: false, maxLength: 100),
                    PlaceHolder = c.String(nullable: false, maxLength: 100),
                    HelpText = c.String(nullable: false, maxLength: 100),
                    Pattern = c.String(nullable: false, maxLength: 100),
                    Required = c.Boolean(nullable: false),
                    Type = c.Int(nullable: false),
                    LastModificationTime = c.DateTime(),
                    LastModifierUserId = c.Long(),
                    CreationTime = c.DateTime(nullable: false),
                    CreatorUserId = c.Long(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GroupInformation", t => t.GroupInformationId)
                .Index(t => t.GroupInformationId);

            CreateTable(
                "dbo.GroupInformation",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    ApplicationFormId = c.Guid(nullable: false),
                    Name = c.String(nullable: false, maxLength: 100),
                    Header = c.String(nullable: false, maxLength: 100),
                    Order = c.Int(nullable: false),
                    LastModificationTime = c.DateTime(),
                    LastModifierUserId = c.Long(),
                    CreationTime = c.DateTime(nullable: false),
                    CreatorUserId = c.Long(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationForm", t => t.ApplicationFormId)
                .Index(t => t.ApplicationFormId);

            CreateTable(
                "dbo.ParameterRequest",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    ApplicationFormRequestId = c.Guid(nullable: false),
                    Name = c.String(nullable: false),
                    Value = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationFormRequest", t => t.ApplicationFormRequestId)
                .Index(t => t.ApplicationFormRequestId);

            CreateTable(
                "dbo.WindowInformation",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    ApplicationFormRequestId = c.Guid(nullable: false),
                    Width = c.Int(nullable: false),
                    Height = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationFormRequest", t => t.Id)
                .Index(t => t.Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.GroupInformation", "ApplicationFormId", "dbo.ApplicationForm");
            DropForeignKey("dbo.ApplicationFormRequest", "ApplicationFormId", "dbo.ApplicationForm");
            DropForeignKey("dbo.WindowInformation", "Id", "dbo.ApplicationFormRequest");
            DropForeignKey("dbo.ParameterRequest", "ApplicationFormRequestId", "dbo.ApplicationFormRequest");
            DropForeignKey("dbo.FieldValue", "ApplicationFormRequestId", "dbo.ApplicationFormRequest");
            DropForeignKey("dbo.FieldAttribute", "GroupInformationId", "dbo.GroupInformation");
            DropForeignKey("dbo.FieldValue", "FieldAttributeId", "dbo.FieldAttribute");
            DropForeignKey("dbo.BrowserInformation", "Id", "dbo.ApplicationFormRequest");
            DropIndex("dbo.WindowInformation", new[] { "Id" });
            DropIndex("dbo.ParameterRequest", new[] { "ApplicationFormRequestId" });
            DropIndex("dbo.GroupInformation", new[] { "ApplicationFormId" });
            DropIndex("dbo.FieldAttribute", new[] { "GroupInformationId" });
            DropIndex("dbo.FieldValue", new[] { "FieldAttributeId" });
            DropIndex("dbo.FieldValue", new[] { "ApplicationFormRequestId" });
            DropIndex("dbo.BrowserInformation", new[] { "Id" });
            DropIndex("dbo.ApplicationFormRequest", new[] { "ApplicationFormId" });
            DropTable("dbo.WindowInformation");
            DropTable("dbo.ParameterRequest");
            DropTable("dbo.GroupInformation");
            DropTable("dbo.FieldAttribute");
            DropTable("dbo.FieldValue");
            DropTable("dbo.BrowserInformation");
            DropTable("dbo.ApplicationFormRequest");
            DropTable("dbo.ApplicationForm");
        }
    }
}
