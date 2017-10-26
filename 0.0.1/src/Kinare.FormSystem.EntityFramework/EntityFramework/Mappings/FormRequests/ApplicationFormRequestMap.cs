using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Kinare.FormSystem.FormRequests;
using Kinare.FormSystem.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Kinare.FormSystem.EntityFramework.Mappings.FormRequests
{
    public class ApplicationFormRequestMap : EntityTypeConfiguration<ApplicationFormRequest>
    {
        const string tableName = "ApplicationFormRequest";

        public ApplicationFormRequestMap()
        {
            this.ToTable(tableName);

            this.HasMany(e => e.ParameterRequestList)
               .WithRequired(e => e.ApplicationFormRequest)
               .WillCascadeOnDelete(false);

            this.HasMany(e => e.FieldValueList)
              .WithRequired(e => e.ApplicationFormRequest)
              .WillCascadeOnDelete(false);

            this.HasRequired(e => e.BrowserInformation)
                .WithRequiredPrincipal(e => e.ApplicationFormRequest)
                .WillCascadeOnDelete(false);

            this.HasRequired(e => e.WindowInformation)
              .WithRequiredPrincipal(e => e.ApplicationFormRequest)
              .WillCascadeOnDelete(false);
        }
    }
}
