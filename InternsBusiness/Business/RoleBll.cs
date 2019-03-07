using System;
using System.Collections.Generic;
using InternsDataAccessLayer.Entities;
using InternsDataAccessLayer.Repository;

namespace InternsBusiness.Business
{
    public class RoleBll : IRoleBll
    {
        private readonly IRoleRepository repository;

        public RoleBll(IRoleRepository repo)
        {
            repository = repo;
        }
        public IList<Role> GetAllRoles()
        {
            return repository.GetAll();
        }

        public Role GetRoleById(int id)
        {
            return repository.GetById(id);
        }
    }
}
