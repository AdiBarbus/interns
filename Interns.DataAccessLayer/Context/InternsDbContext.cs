//using System.Data.Entity;
//using Interns.Core;
//using Interns.Core.Data;

//namespace Interns.DataAccessLayer.Context
//{
//    public class InternsDbContext : DbContext, IDbContext
//    {
//        public InternsDbContext() : base("AppContext")
//        {
//        }
//        public IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
//        {
//            return base.Set<TEntity>();
//        }

//        public DbSet<User> Users { get; set; }
//        public DbSet<Domain> Domains { get; set; }
//        public DbSet<SubDomain> SubDomains { get; set; }
//        public DbSet<Address> Addresses { get; set; }
//        public DbSet<Advertise> Advertisments { get; set; }
//        public DbSet<Qa> QAs { get; set; }
//        public DbSet<Role> Roles { get; set; }
//    }
//}
