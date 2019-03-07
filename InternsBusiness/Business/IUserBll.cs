using System.Collections.Generic;
using InternsDataAccessLayer.Entities;

namespace InternsBusiness.Business
{
    public interface IUserBll
    {
        IList<User> GetAllUsers();
        User GetUserById(int id);
        void AddUser(User user);
        void DeleteUser(int id);
        void EditUser(User user);
        void Save();
    }
}