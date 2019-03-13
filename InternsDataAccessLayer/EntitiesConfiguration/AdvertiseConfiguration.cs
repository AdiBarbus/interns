using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternsDataAccessLayer.Entities;

namespace InternsBusiness.EntitiesConfiguration
{
    static class AdvertiseConfiguration
    {
        public static void Configure(DbModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Advertise>();

            entity.Property(a => a.Id)
                .IsRequired()
                .HasColumnName("AdvertiseId")
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
        }
    }
}
