using System.Collections.Generic;
using InternsDataAccessLayer.Entities;
using InternsDataAccessLayer.Repository;

namespace InternsServices.Service
{
    public class RoleService : IRoleService
    {
        private readonly IGenericRepository<Role> repository;

        public RoleService(IGenericRepository<Role> repo)
        {
            repository = repo;
        }
        public IList<Role> GetAllRoles()
        {
            return repository.GetAll();
        }

        public Role GetRoleById(int id)
        {
            return repository.GetById(id); //a => a.Id == id);
        }
    }
}
