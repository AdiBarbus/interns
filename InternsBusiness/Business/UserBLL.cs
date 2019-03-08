using System.Collections.Generic;
using InternsDataAccessLayer.Entities;
using InternsDataAccessLayer.Repository;

namespace InternsBusiness.Business
{
    public class UserBll : IUserBll
    {
        private readonly IUserRepository repository;

        public UserBll(IUserRepository repo)
        {
            repository = repo;
        }

        public IList<User> GetAllUsers()
        {
            return repository.GetAll(e => e.Role);
        }

        public User GetUserById(int id)
        {
            return repository.GetById(a => a.Id == id, d => d.Role);
        }

        public void AddUser(User user)
        {
            if (user != null)
            {
                repository.Insert(user);
                Save();
            }
        }

        public void DeleteUser(int id)
        {
            repository.Delete(id);
            Save();
        }

        public void EditUser(User user)
        {
            repository.Update(user);
            Save();
        }

        public void Save()
        {
            repository.Save();
        }
    }
}
