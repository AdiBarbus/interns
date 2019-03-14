using System.Collections.Generic;
using InternsDataAccessLayer.Entities;

namespace InternsServices.Service
{
    public interface IRoleService
    {
        IList<Role> GetAllRoles();
        Role GetRoleById(int id);
    }
}
