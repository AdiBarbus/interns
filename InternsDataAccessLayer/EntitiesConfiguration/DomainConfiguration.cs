using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternsDataAccessLayer.Entities;

namespace InternsServices.EntitiesConfiguration
{
    static class DomainConfiguration
    {
        public static void Configure(DbModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Domain>();

            entity.Property(a => a.Id)
                .IsRequired()
                .HasColumnName("DomainId")
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
        }
    }
}
