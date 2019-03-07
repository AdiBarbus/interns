using InternsDataAccessLayer.Entities;

namespace InternsDataAccessLayer.Repository
{
    public interface IAddressRepository : IGenericRepository<Address> { }
    public interface IAdvertismentRepository : IGenericRepository<Advertisment> { }
    public interface IDomainRepository : IGenericRepository<Domain> { }
    public interface IQaRepository : IGenericRepository<QA> { }
    public interface IRoleRepository : IGenericRepository<Role> { }
    public interface ISubDomainRepository : IGenericRepository<SubDomain> { }
    public interface IUserRepository : IGenericRepository<User> { }

    public class AddressRepository : GenericRepository<Address>, IAddressRepository { }
    public class AdvertismentRepository : GenericRepository<Advertisment>, IAdvertismentRepository { }
    public class DomainRepository : GenericRepository<Domain>, IDomainRepository { }
    public class QaRepository : GenericRepository<QA>, IQaRepository { }
    public class RoleRepository : GenericRepository<Role>, IRoleRepository { }
    public class SubDomainRepository : GenericRepository<SubDomain>, ISubDomainRepository { }
    public class UserRepository : GenericRepository<User>, IUserRepository { }
}
