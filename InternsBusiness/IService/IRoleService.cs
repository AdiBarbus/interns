using System.Collections.Generic;
using InternsDataAccessLayer.Entities;

namespace InternsServices.IService
{
    public interface IRoleService
    {
        IList<Role> GetAllRoles();
        Role GetRoleById(int id);
    }
}
