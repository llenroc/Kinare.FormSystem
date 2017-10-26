using Abp.Domain.Entities;
using Kinare.FormSystem.FormRequests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinare.FormSystem.EntityFramework.Mappings.FormRequests
{
    public class BrowserInformationMap : EntityTypeConfiguration<BrowserInformation>
    {
        const string tableName = "BrowserInformation";

        public BrowserInformationMap()
        {
            this.ToTable(tableName);
        }
    }
}
