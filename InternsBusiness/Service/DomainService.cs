﻿using System.Collections.Generic;
using System.Linq;
using InternsDataAccessLayer.Entities;
using InternsDataAccessLayer.Repository;
using InternsServices.IService;

namespace InternsServices.Service
{
    public class DomainService : IDomainService
    {
        private readonly IGenericRepository<Domain> repository;
        private readonly IGenericRepository<SubDomain> subDomainRepository;
        private readonly IGenericRepository<Advertise> advertiseRepository;

        public DomainService(IGenericRepository<Domain> repo, IGenericRepository<SubDomain> subDomainRepo, IGenericRepository<Advertise> advertiseRepo)
        {
            repository = repo;
            subDomainRepository = subDomainRepo;
            advertiseRepository = advertiseRepo;
        }

        public IList<SubDomain> GetSubDomainsByDomain(int domainId)
        {
            return subDomainRepository.GetAll().Where(e => e.DomainId == domainId).ToList();
        }

        public IList<Advertise> GetAdvertisesByDomain(int domainId)
        {
            return advertiseRepository.GetAll().Where(e => e.DomainId == domainId).ToList();
        }

        public IList<Domain> GetAllDomains()
        {
            return repository.GetAll();
        }

        public Domain GetDomainById(int id)
        {
            return repository.GetById(id); //a => a.Id == id);
        }

        public void AddDomain(Domain domain)
        {
            if (domain != null) repository.Insert(domain);
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