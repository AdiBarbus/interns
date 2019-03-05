using System.Data.Entity;
using InternsDataAccessLayer.Entities;

namespace InternsDataAccessLayer.Context
{
    public class AppContext : DbContext
    {
        public AppContext() : base("AppContext")
        {
            Database.SetInitializer<AppContext>(new CreateDatabaseIfNotExists<AppContext>());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Domain> Domains { get; set; }
        public DbSet<SubDomain> SubDomains { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Advertisment> Advertisments { get; set; }
        public DbSet<QA> QAs { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
