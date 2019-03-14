using System.Collections.Generic;
using InternsDataAccessLayer.Entities;

namespace InternsServices.Service
{
    public interface IDomainService
    {
        IList<Domain> GetAllDomains();
        IList<SubDomain> GetSubDomainsByDomain(int id);
        IList<Advertise> GetAdvertisesByDomain(int id);
        Domain GetDomainById(int id);
        void AddDomain(Domain domain);
        void DeleteDomain(int id);
        void EditDomain(Domain domain);
    }
}