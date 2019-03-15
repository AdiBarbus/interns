using System.Data.Entity;
using InternsDataAccessLayer.Entities;

namespace InternsDataAccessLayer.Context
{
    public class AppContext : DbContext
    {
        public AppContext() : base("AppContext")
        {
            //Database.SetInitializer<AppContext>(new CreateDatabaseIfNotExists<AppContext>());
            //Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Domain> Domains { get; set; }
        public DbSet<SubDomain> SubDomains { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Advertise> Advertisments { get; set; }
        public DbSet<Qa> QAs { get; set; }
        public DbSet<Role> Roles { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    ConfigureModels(modelBuilder);
        //    base.OnModelCreating(modelBuilder);
        //}

        //private void ConfigureModels(DbModelBuilder modelBuilder)
        //{
        //    AdvertiseConfiguration.Configure(modelBuilder);
        //    DomainConfiguration.Configure(modelBuilder);
        //    QAConfiguration.Configure(modelBuilder);
        //    SubdomainConfiguration.Configure(modelBuilder);
        //    UserConfiguration.Configure(modelBuilder);
        //}
    }
}
