using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UserTable.Server.Data.Abstract;

namespace UserTable.Server.Data.Repositories
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, new()
    {
        private Profico_DB_Context _context;

        public EntityBaseRepository(Profico_DB_Context context)
        {
            _context = context;
        }

        #region PrivateMethods

        private void SetEntityState(T entity, EntityState state)
        {
            EntityEntry dbEntityEntry = _context.Entry<T>(entity);
            dbEntityEntry.State = state;
        }

        private bool ContextHasChanges()
        {
            return _context.ChangeTracker.Entries()
                .Any(
                e => e.State == EntityState.Added
                || e.State == EntityState.Deleted
                || e.State == EntityState.Modified);
        }

        #endregion PrivateMethods

        public virtual void Add(T entity)
        {
            SetEntityState(entity, EntityState.Added);
        }

        public virtual void Update(T entity)
        {
            SetEntityState(entity, EntityState.Modified);
        }

        public virtual void Delete(T entity)
        {
            SetEntityState(entity, EntityState.Deleted);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public virtual IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.AsQueryable();
        }

        public virtual void SaveChanges()
        {
            if (ContextHasChanges())
                _context.SaveChanges();
        }

        public virtual async Task SaveChangesAsync()
        {
            if (ContextHasChanges())
                await _context.SaveChangesAsync();
            else
                await Task.CompletedTask;
        }
    }
}