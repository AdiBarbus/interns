using System.Linq;
using Interns.Core.Data;
using Interns.DataAccessLayer.Repository;
using Interns.Services.IService;

namespace Interns.Services.Service
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> repository;

        public UserService(IRepository<User> repo)
        {
            repository = repo;
        }

        public IQueryable<User> GetUsers()
        {
            return repository.GetAll();
        }

        public User GetUser(int id)
        {
            return repository.GetById(id);
        }

        public void InsertUser(User user)
        {
            if (user != null)
            {
                repository.Insert(user);
            }
        }

        public void DeleteUser(User user)
        {
            repository.Delete(user);
        }

        public void UpdateUser(User user)
        {
            repository.Update(user);
        }
    }
}
