using System.Collections.Generic;
using InternsDataAccessLayer.Entities;

namespace InternsBusiness.Business
{
    public interface IRoleBll
    {
        IList<Role> GetAllRoles();
        Role GetRoleById(int id);
    }
}
