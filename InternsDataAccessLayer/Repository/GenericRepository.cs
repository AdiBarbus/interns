using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AppContext = InternsDataAccessLayer.Context.AppContext;

namespace InternsDataAccessLayer.Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppContext context = new AppContext();

        public virtual IList<T> GetAll(params Expression<Func<T, object>>[] predicate)
        {
            List<T> list;
            using (context)
            {
                IQueryable<T> dbQuery = context.Set<T>();

                //Apply eager loading
                foreach (var item in predicate)
                    dbQuery = dbQuery.Include(item);

                list = dbQuery
                    .AsNoTracking()
                    .ToList();
            }
            return list;
        }

        public T GetById(int id)
        {
            T user;
            using (context)
            {
                user = context.Set<T>().Find(id);
            }
            return user;
        }

        public void Insert(T item)
        {
            using (context)
            {
                context.Set<T>().Add(item);
                Save();
            }
        }

        public void Delete(int id)
        {
            using (context)
            {
                var user = context.Set<T>().Find(id);
                if (user != null)
                {
                    context.Set<T>().Remove(user);
                    Save();
                }
            }
        }

        public void Update(T item)
        {
            using (context)
            {
                if (item != null)
                {
                    context.Entry(item).CurrentValues.SetValues(item);
                    Save();
                }
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}