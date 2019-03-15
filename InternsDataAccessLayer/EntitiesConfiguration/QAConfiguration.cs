using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternsDataAccessLayer.Entities;

namespace InternsServices.EntitiesConfiguration
{
    static class QAConfiguration
    {
        public static void Configure(DbModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Qa>();

            entity.Property(a => a.Id)
                .IsRequired()
                .HasColumnName("QAsId")
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
        }
    }
}
