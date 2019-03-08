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

        public T GetById(Func<T, bool> where, params Expression<Func<T, object>>[] predicate)
        {
            T user;
            using (context)
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
                var user = context.Set<T>().FirstOrDefault(t => t.Id == id);
                if (user != null)
                {
                    context.Set<T>().Remove(user);
                    Save();
                }
            }
        }

        public void Update(T item)
        {
            using (var contex = new AppContext())
            {
                var entity = contex.Set<T>().Where(t => t.Id == item.Id);
                if (entity != null)
                {
                    context.Entry(entity).CurrentValues.SetValues(item);
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