using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using InternsDataAccessLayer.Entities;
using AppContext = InternsDataAccessLayer.Context.AppContext;

namespace InternsDataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseClass
    {
        private readonly AppContext context;
        private readonly DbSet<T> table;
        public GenericRepository()
        {
            context = new AppContext();
            table = context.Set<T>();
        }
        public GenericRepository(AppContext context)
        {
            this.context = context;
            table = context.Set<T>();
        }

    public virtual IList<T> GetAll(params Expression<Func<T, object>>[] predicate)
        {
            List<T> list;
            using (context)
            {
                IQueryable<T> dbQuery = table;

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
            return table.FirstOrDefault(e => e.Id == id);
        }

        public void Insert(T item)
        {
            using (context)
            {
                table.Add(item);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (context)
            {
                var user = table.FirstOrDefault(t => t.Id == id);
                if (user != null)
                {
                    table.Remove(user);
                    context.SaveChanges();
                }
            }
        }

        public void Update(T item)
        {
            using (context)
            {
                table.Attach(item);
                context.Entry(item).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}