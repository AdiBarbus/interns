using System.Linq;
using Interns.Core.Data;
using Interns.DataAccessLayer.Repository;
using Interns.Services.IService;

namespace Interns.Services.Service
{
    public class DomainService : IDomainService
    {
        private readonly IRepository<Domain> repository;
        private readonly IRepository<SubDomain> subDomainRepository;
        private readonly IRepository<Advertise> advertiseRepository;

        public DomainService(IRepository<Domain> repo, IRepository<SubDomain> subDomainRepo, IRepository<Advertise> advertiseRepo)
        {
            repository = repo;
            subDomainRepository = subDomainRepo;
            advertiseRepository = advertiseRepo;
        }

        public IQueryable<SubDomain> GetSubDomainsByDomain(int domainId)
        {
            return subDomainRepository.GetAll().Where(e => e.DomainId == domainId);
        }

        public IQueryable<Advertise> GetAdvertisesByDomain(int domainId)
        {
            return advertiseRepository.GetAll().Where(e => e.DomainId == domainId);
        }

        public IQueryable<Domain> GetDomains()
        {
            return repository.GetAll();
        }

        public Domain GetDomain(int id)
        {
            return repository.GetById(id); //a => a.Id == id);
        }

        public void InsertDomain(Domain domain)
        {
            if (domain != null) repository.Insert(domain);
        }

        public void DeleteDomain(Domain domain)
        {
            repository.Delete(domain);
        }

        public void UpdateDomain(Domain domain)
        {
            repository.Update(domain);
        }
    }
}