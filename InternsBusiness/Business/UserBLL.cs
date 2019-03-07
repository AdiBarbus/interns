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
            return repository.GetAll();
        }

        public User GetUserById(int id)
        {
            return repository.GetById(id);
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
