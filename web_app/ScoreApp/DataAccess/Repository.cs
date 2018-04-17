using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace ScoreApp.DataAccess
{
    public interface IRepository<T>
    {
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity, T newValue);
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
        IQueryable<T> SelectAll();
        void SubmitAll();
    }

    public class Repository<T> : IRepository<T> where T : class
    {
        protected DatabaseContext DBContext { get; set; }

        public Repository(DatabaseContext dataContext)
        {
            DBContext = dataContext;
        }

        public void Insert(T entity)
        {
            DBContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            DBContext.Set<T>().Remove(entity);
        }

        public void Update(T entity, T newValue)
        {
            var entry = DBContext.Entry<T>(entity);
            entry.CurrentValues.SetValues(newValue);
            entry.State = EntityState.Modified;
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return DBContext.Set<T>().Where(predicate);
        }

        public IQueryable<T> SelectAll()
        {
            return DBContext.Set<T>();
        }

        public void SubmitAll()
        {
            DBContext.SaveChanges();
        }
    }
}
