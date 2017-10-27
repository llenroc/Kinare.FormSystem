namespace Kinare.FormSystem.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModelFullAuditedEntity : DbMigration
    {
        public override void Up()
        {
            AlterTableAnnotations(
                "dbo.ApplicationForm",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Header = c.String(nullable: false, maxLength: 100),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_ApplicationForm_SoftDelete",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
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
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_FieldAttribute_SoftDelete",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.GroupInformation",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ApplicationFormId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Header = c.String(nullable: false, maxLength: 100),
                        Order = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_GroupInformation_SoftDelete",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AddColumn("dbo.ApplicationForm", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.ApplicationForm", "DeleterUserId", c => c.Long());
            AddColumn("dbo.ApplicationForm", "DeletionTime", c => c.DateTime());
            AddColumn("dbo.FieldAttribute", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.FieldAttribute", "DeleterUserId", c => c.Long());
            AddColumn("dbo.FieldAttribute", "DeletionTime", c => c.DateTime());
            AddColumn("dbo.GroupInformation", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.GroupInformation", "DeleterUserId", c => c.Long());
            AddColumn("dbo.GroupInformation", "DeletionTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.GroupInformation", "DeletionTime");
            DropColumn("dbo.GroupInformation", "DeleterUserId");
            DropColumn("dbo.GroupInformation", "IsDeleted");
            DropColumn("dbo.FieldAttribute", "DeletionTime");
            DropColumn("dbo.FieldAttribute", "DeleterUserId");
            DropColumn("dbo.FieldAttribute", "IsDeleted");
            DropColumn("dbo.ApplicationForm", "DeletionTime");
            DropColumn("dbo.ApplicationForm", "DeleterUserId");
            DropColumn("dbo.ApplicationForm", "IsDeleted");
            AlterTableAnnotations(
                "dbo.GroupInformation",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ApplicationFormId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Header = c.String(nullable: false, maxLength: 100),
                        Order = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_GroupInformation_SoftDelete",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
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
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_FieldAttribute_SoftDelete",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.ApplicationForm",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Header = c.String(nullable: false, maxLength: 100),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_ApplicationForm_SoftDelete",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
        }
    }
}
