using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using Interns.Core;
using AppContext = Interns.DataAccessLayer.Context.AppContext;

namespace Interns.DataAccessLayer.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppContext context;
        private readonly DbSet<T> table;

        public Repository()
        {
            context = new AppContext();
            table = context.Set<T>();
        }

        public Repository(AppContext context)
        {
            this.context = context;
            table = context.Set<T>();
        }

        public virtual IQueryable<T> GetAll()
        {
            return table;
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }

        public void Insert(T item)
        {
            try
            {
                using (context)
                {
                    if (item != null)
                    {
                        table.Add(item);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new ArgumentNullException(nameof(item));
                    }
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                foreach (var validationError in validationErrors.ValidationErrors)
                    msg += $"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}" +
                           Environment.NewLine;

                var fail = new Exception(msg, dbEx);
                throw fail;
            }
        }

        public void Update(T item)
        {
            try
            {
                using (context)
                {
                    var entity = context.Set<T>().Where(t => t.Id == item.Id).FirstOrDefault();
                    if (entity != null)
                    {
                        context.Entry(entity).CurrentValues.SetValues(item);
                        context.SaveChanges();
                    }
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                foreach (var validationError in validationErrors.ValidationErrors)
                    msg += Environment.NewLine +
                           $"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}";
                var fail = new Exception(msg, dbEx);
                throw fail;
            }
        }


        public void Delete(T item)
        {
            try
            {
                using (context)
                {
                    var entity = context.Set<T>().FirstOrDefault(t => t.Id == item.Id);
                    if (entity != null)
                    {
                        context.Set<T>().Remove(entity);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new ArgumentNullException(nameof(item));
                    }
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                foreach (var validationError in validationErrors.ValidationErrors)
                    msg += Environment.NewLine +
                           $"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}";
                var fail = new Exception(msg, dbEx);
                throw fail;
            }
        }
    }
}