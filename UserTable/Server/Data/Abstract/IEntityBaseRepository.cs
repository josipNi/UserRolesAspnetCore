using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace UserTable.Server.Data.Abstract
{
    public interface IEntityBaseRepository<T> where T : class, new()
    {
        // define all Methods you want your repo to have.
        IQueryable<T> GetAll();

        Task SaveChangesAsync();

        void Add(T entity);

        void Delete(T entity);

        void SaveChanges();

        void Update(T entity);

        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
    }
}