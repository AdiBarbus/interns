using System.Collections.Generic;
using InternsDataAccessLayer.Entities;

namespace InternsBusiness.Business
{
    public interface IDomainBll
    {
        IList<Domain> GetAllDomains();
        IList<SubDomain> GetSubDomainsByDomain(int id);
        Domain GetDomainById(int id);
        void AddDomain(Domain domain);
        void DeleteDomain(int id);
        void EditDomain(Domain domain);
    }
}