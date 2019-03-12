using System.Collections.Generic;
using InternsDataAccessLayer.Entities;
using InternsDataAccessLayer.Repository;

namespace InternsBusiness.Business
{
    public class SubDomainBll : ISubDomainBll
    {
        private readonly ISubDomainRepository repository;

        public SubDomainBll(ISubDomainRepository repo)
        {
            repository = repo;
        }

        public IList<SubDomain> GetAllSubDomains()
        {
            return repository.GetAll();
        }

        public SubDomain GetSubDomainById(int id)
        {
            return repository.GetById(a => a.Id == id);
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
