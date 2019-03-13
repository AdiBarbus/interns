using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternsDataAccessLayer.Entities;
using AppContext = InternsDataAccessLayer.Context.AppContext;
using Exception = System.Exception;

namespace InternsDataAccessLayer.Repository
{
    public class UserRepositoryy
    {
        AppContext context = new AppContext();
        public void Add(User item)
        {
            try
            {
                using (context)
                {
                    context.Users.Add(item);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<User> GetAll()
        {
            var list = new List<User>();
            try
            {
                using (context)
                {
                    foreach (var user in context.Users)
                    {
                        list.Add(user);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return list;
        }

        public User GetById(int id)
        {
            User user = null;
            using (context)
            {
                user = context.Users.FirstOrDefault(e => e.Id == id);
            }

            return user;
        }

        public void Delete(int id)
        {
            try
            {
                using (context)
                {
                    var user = context.Users.FirstOrDefault(e => e.Id == id);
                    context.Users.Remove(user);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public User Update(User user)
        {
            try
            {
                using (context)
                {
                    var entity = context.Users.FirstOrDefault(e => e.Id == user.Id);
                    if (entity != null)
                    {
                        context.Entry(entity).CurrentValues.SetValues(user);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return user;
        }
    }
}
