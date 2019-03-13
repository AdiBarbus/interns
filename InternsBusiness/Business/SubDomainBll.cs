using System.Collections.Generic;
using System.Linq;
using InternsDataAccessLayer.Entities;
using InternsDataAccessLayer.Repository;

namespace InternsBusiness.Business
{
    public class SubDomainBll : ISubDomainBll
    {
        private readonly ISubDomainRepository repository;
        private readonly IAdvertiseRepository advertiseRepository;

        public SubDomainBll(ISubDomainRepository repo, IAdvertiseRepository advertiseRepo)
        {
            repository = repo;
            advertiseRepository = advertiseRepo;
        }

        public IList<SubDomain> GetAllSubDomains()
        {
            return repository.GetAll();
        }

        public SubDomain GetSubDomainById(int id)
        {
            return repository.GetById(a => a.Id == id);
        }
        public IList<Advertise> GetAdvertisesBySubDomain(int domainId)
        {
            return advertiseRepository.GetAll().Where(e => e.DomainId == domainId).Where(e => e.SubDomainId==domainId).ToList();
        }

        public void AddSubDomain(SubDomain subDomain)
        {
            if (subDomain != null)
            {
                repository.Insert(subDomain);
            }
        }

        public void DeleteSubDomain(int id)
        {
            repository.Delete(id);
        }

        public void EditSubDomain(SubDomain subDomain)
        {
            repository.Update(subDomain);
        }
    }
}
