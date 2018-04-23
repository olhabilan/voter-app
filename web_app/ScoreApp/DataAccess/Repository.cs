using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ScoreApp.DataAccess
{
    public interface IRepository<T>
    {
        DatabaseContext DBContext { get; }
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity, T newValue);
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
        IQueryable<T> SelectAll();
        Task SubmitAllAsync();
    }

    public class Repository<T> : IRepository<T> where T : class
    {
        public DatabaseContext DBContext { get; }

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

        public async Task SubmitAllAsync()
        {
            await DBContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
