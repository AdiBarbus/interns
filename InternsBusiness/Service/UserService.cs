using System.Collections.Generic;
using InternsServices.IService;
using InternsDataAccessLayer.Entities;
using InternsDataAccessLayer.Repository;

namespace InternsServices.Service
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> repository;

        public UserService(IGenericRepository<User> repo)
        {
            repository = repo;
        }

        public IList<User> GetAllUsers()
        {
            return repository.GetAll(e => e.Role);
        }

        public User GetUserById(int id)
        {
            return repository.GetById(id); //a => a.Id == id, d => d.Role);
        }

        public void AddUser(User user)
        {
            if (user != null)
            {
                repository.Insert(user);
            }
        }

        public void DeleteUser(int id)
        {
            repository.Delete(id);
        }

        public void EditUser(User user)
        {
            repository.Update(user);
        }
    }
}
