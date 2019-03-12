using System.Collections.Generic;
using InternsDataAccessLayer.Entities;

namespace InternsBusiness.Business
{
    public interface ISubDomainBll
    {
        IList<SubDomain> GetAllSubDomains();
        SubDomain GetSubDomainById(int id);
        IList<Advertise> GetAdvertisesBySubDomain(int domainId);
        void AddSubDomain(SubDomain subDomain);
        void DeleteSubDomain(int id);
        void EditSubDomain(SubDomain subDomain);
    }
}