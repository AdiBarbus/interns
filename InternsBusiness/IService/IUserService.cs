using System.Collections.Generic;
using InternsDataAccessLayer.Entities;

namespace InternsServices.Service
{
    public interface IUserService
    {
        IList<User> GetAllUsers();
        User GetUserById(int id);
        void AddUser(User user);
        void DeleteUser(int id);
        void EditUser(User user);
    }
}