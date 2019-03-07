using System.Collections.Generic;
using System.Linq;
using InternsDataAccessLayer.Entities;

namespace InternsDataAccessLayer.Repository
{
    public interface IUserRepositoryy
    {
        void Add(User item);
        IQueryable<User> GetAll();
        User GetById(int id);
        void Delete(int id);
        User Update(User user);
    }
}