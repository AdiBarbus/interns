using System.Linq;
using Interns.Core.Data;
using Interns.DataAccessLayer.Repository;
using Interns.Services.IService;

namespace Interns.Services.Service
{
    public class SubDomainService : ISubDomainService
    {
        private readonly IRepository<SubDomain> repository;
        private readonly IRepository<Advertise> advertiseRepository;

        public SubDomainService(IRepository<SubDomain> repo, IRepository<Advertise> advertiseRepo)
        {
            repository = repo;
            advertiseRepository = advertiseRepo;
        }

        public IQueryable<SubDomain> GetSubDomains()
        {
            return repository.GetAll();
        }

        public SubDomain GetSubDomain(int id)
        {
            return repository.GetById(id); //a => a.Id == id);
        }
        public IQueryable<Advertise> GetAdvertisesBySubDomain(int domainId)
        {
            return advertiseRepository.GetAll().Where(e => e.DomainId == domainId).Where(e => e.SubDomainId==domainId);
        }

        public void InsertSubDomain(SubDomain subDomain)
        {
            if (subDomain != null)
            {
                repository.Insert(subDomain);
            }
        }

        public void DeleteSubDomain(SubDomain subDomain)
        {
            repository.Delete(subDomain);
        }

        public void UpdateSubDomain(SubDomain subDomain)
        {
            repository.Update(subDomain);
        }
    }
}
