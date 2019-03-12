using System.Collections.Generic;
using System.Linq;
using InternsDataAccessLayer.Entities;
using InternsDataAccessLayer.Repository;

namespace InternsBusiness.Business
{
    public class DomainBll : IDomainBll
    {
        private readonly IDomainRepository repository;
        private readonly ISubDomainRepository subDomainRepository;

        public DomainBll(IDomainRepository repo, ISubDomainRepository subDomainRepo)
        {
            repository = repo;
            subDomainRepository = subDomainRepo;
        }

        public IList<SubDomain> GetSubDomainsByDomain(int domainId)
        {
            //var b = subDomainRepository.GetAll().Where(e => e.DomainId == domainId).ToList();
            //Dictionary<string,SubDomain> dictionary = new Dictionary<string, SubDomain>();

            //foreach (var subDomain in b)
            //{
            //    dictionary.Add(subDomain.Name,subDomain);
            //}

            return subDomainRepository.GetAll().Where(e => e.DomainId == domainId).ToList();
            //return dictionary;
        }

        public IList<Domain> GetAllDomains()
        {
            return repository.GetAll();
        }

        public Domain GetDomainById(int id)
        {
            return repository.GetById(a => a.Id == id);
        }

        public void AddDomain(Domain domain)
        {
            if (domain != null)
            {
                repository.Insert(domain);
            }
        }

        public void DeleteDomain(int id)
        {
            repository.Delete(id);
        }

        public void EditDomain(Domain domain)
        {
            repository.Update(domain);
        }
    }
}
