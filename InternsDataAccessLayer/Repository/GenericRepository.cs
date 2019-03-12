using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using InternsDataAccessLayer.Entities;
using AppContext = InternsDataAccessLayer.Context.AppContext;

namespace InternsDataAccessLayer.Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : BaseClass
    {
        public virtual IList<T> GetAll(params Expression<Func<T, object>>[] predicate)
        {
            List<T> list;
            using (var context = new AppContext())
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

        public T GetById(Func<T, bool> where, params Expression<Func<T, object>>[] predicate)
        {
            T user;
            using (var context = new AppContext())
            {
                IQueryable<T> dbQuery = context.Set<T>();

                //Apply eager loading
                foreach (Expression<Func<T, object>> navigationProperty in predicate)
                    dbQuery = dbQuery.Include(navigationProperty);

                user = dbQuery
                    .AsNoTracking() //Don't track any changes for the selected item
                    .FirstOrDefault(where); //Apply where clause
            }
            return user;
        }

        public void Insert(T item)
        {
            using (var context = new AppContext())
            {
                context.Set<T>().Add(item);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = new AppContext())
            {
                var user = context.Set<T>().FirstOrDefault(t => t.Id == id);
                if (user != null)
                {
                    context.Set<T>().Remove(user);
                    context.SaveChanges();
                }
            }
        }

        public void Update(T item)
        {
            using (var context = new AppContext())
            {
                context.Set<T>().Attach(item);
                context.Entry(item).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}