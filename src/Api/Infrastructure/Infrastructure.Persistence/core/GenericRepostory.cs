using Core.Application.Interfaces.core;
using Core.Domain.Bases;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Persistence.core
{
    public class GenericRepostory<T> : IGenericRepostory<T> where T : BaseEntity<int>
    {
        private DbContext _context;
        protected DbSet<T> _entities;

        public GenericRepostory(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _entities = _context.Set<T>();
        }

        #region ::ADDS::

        #region :::AddAsync::

        public async Task<int> AddAsync(T entity)
        {
            await _entities.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> AddRagneAsync(IEnumerable<T> entities)
        {
            await _entities.AddRangeAsync(entities);
            return await _context.SaveChangesAsync();
        }

        #endregion :::AddAsync::

        #region ::Add::

        public int Add(T entity)
        {
            var result = _entities.Add(entity);
            return _context.SaveChanges();
        }

        public int AddRagne(IEnumerable<T> entities)
        {
            _entities.AddRange(entities);
            return _context.SaveChanges();
        }

        #endregion ::Add::

        #region ::AddOrUpdate::

        public int AddOrUpdate(T entity)
        {
            if (!_entities.Local.Any(x => EqualityComparer<int>.Default.Equals(x.Id, entity.Id)))
            {
                _context.Update(entity);
            }
            return _context.SaveChanges();
        }

        public Task<int> AddOrUpdateAsync(T entity)
        {
            if (!_entities.Local.Any(x => EqualityComparer<int>.Default.Equals(x.Id, entity.Id)))
            {
                _context.Update(entity);
            }
            return _context.SaveChangesAsync();
        }

        #endregion ::AddOrUpdate::

        #endregion ::ADDS::

        #region ::UPDATES::

        #region ::UpdateAsync::

        public virtual async Task<int> UpdateAsync(T entity)
        {
            _entities.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateRagneAsync(IEnumerable<T> entities)
        {
            _entities.AttachRange(entities);
            _context.Entry(entities).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        #endregion ::UpdateAsync::

        #region ::Update::

        public virtual int Update(T entity)
        {
            _entities.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChanges();
        }

        public virtual int UpdateRagne(IEnumerable<T> entities)
        {
            _entities.AttachRange(entities);
            _context.Entry(entities).State = EntityState.Modified;
            return _context.SaveChanges();
        }

        #endregion ::Update::

        #endregion ::UPDATES::

        #region ::BULK::

        public virtual async Task BulkAdd(IEnumerable<T> entitys)
        {
            if (entitys == null && !entitys.Any())
                await Task.CompletedTask;
            await _context.AddRangeAsync(entitys);
            await _context.SaveChangesAsync();
        }

        public virtual Task BulkDelete(Expression<Func<T, bool>> peridicat)
        {
            if (peridicat == null)
                return Task.CompletedTask;
            _context.Remove(peridicat);
            return _context.SaveChangesAsync();
        }

        public virtual async Task BulkDelete(IEnumerable<T> entitys)
        {
            if (entitys == null && !await _entities.AnyAsync())
                await Task.CompletedTask;
            _context.RemoveRange(entitys);
            await _context.SaveChangesAsync();
        }

        public virtual Task BulkDeleteById(IEnumerable<int> Id)
        {
            if (Id == null && !Id.Any())
                return Task.CompletedTask;
            _context.RemoveRange(_entities.Where(i => Id.Contains(i.Id)));
            return _context.SaveChangesAsync();
        }

        public virtual async Task BulkUpdate(IEnumerable<T> entitys)
        {
            if (_entities == null && !await _entities.AnyAsync())
                await Task.CompletedTask;
            _entities.UpdateRange(entitys);
            await _context.SaveChangesAsync();
        }

        #endregion ::BULK::

        #region ::DELETES::

        public virtual int Delete(T entity)
        {
            if (_context.Entry<T>(entity).State == EntityState.Detached)
            {
                _entities.Attach(entity);
            }
            _entities.Remove(entity);
            return _context.SaveChanges();
        }

        public virtual int Delete(int id)
        {
            var entity = _entities.Find(id);
            return Delete(entity);
        }

        public virtual async Task<int> DeleteAsync(int id)
        {
            var entity = _entities.Find(id);
            return await DeleteAsync(entity);
        }

        public virtual async Task<int> DeleteAsync(T entity)
        {
            if (_context.Entry<T>(entity).State == EntityState.Detached)
            {
                _entities.Attach(entity);
            }
            _entities.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public bool DeleteRange(Expression<Func<T, bool>> perdicate)
        {
            _context.RemoveRange(_entities.Where(perdicate));
            return _context.SaveChanges() > 0;
        }

        public virtual async Task<bool> DeleteRangeAsync(Expression<Func<T, bool>> perdicate)
        {
            _context.RemoveRange(perdicate);
            return await _context.SaveChangesAsync() > 0;
        }

        #endregion ::DELETES::

        #region ::GET::

        public virtual IQueryable<T> Get(Expression<Func<T, bool>> peridicate, bool noTracking = true, params Expression<Func<T, object>>[] includes)
        {
            var query = _entities.AsQueryable();
            if (peridicate == null)
            {
                query = query.Where(peridicate);
            }
            query = ApplyIncludes(query, includes);
            if (noTracking)
                query = query.AsNoTracking();
            return query;
        }

        public virtual IQueryable<T> GetAll()
        {
            return _entities.AsQueryable();
        }

        public virtual Task<List<T>> GetAll(bool noTracking = true)
        {
            if (noTracking)
            {
                return _entities.AsNoTracking().ToListAsync();
            }
            else
            {
                return _entities.ToListAsync();
            }
        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            var result = _entities.AsQueryable();
            return await Task.FromResult(result);
        }

        public T GetById(int id)
        {
            T found = _entities.Find(id);
            if (found == null)
                return null;
            else
                return found;
        }

        public async Task<T> GetByIdAsync(int id, bool noTracking = true, params Expression<Func<T, object>>[] includes)
        {
            T found = await _entities.FindAsync(id);
            if (found == null)
                return null;
            if (noTracking)
                _context.Entry(found).State = EntityState.Detached;
            foreach (var item in includes)
            {
                _context.Entry(found).Reference(item).Load();
            }
            return found;
        }

        public Task<List<T>> GetList(Expression<Func<T, bool>> peridicate, bool noTracking = true, IOrderedQueryable<T> order = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _entities;
            if (peridicate != null)
            {
                query = query.Where(peridicate);
            }
            if (order != null)
            {
                query = query.OrderBy(peridicate);
            }
            if (noTracking)
            {
                query = query.AsNoTracking();
            }
            query = ApplyIncludes(query, includes);
            return query.ToListAsync();
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> peridicate, bool noTracking = true, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _entities;
            if (peridicate != null)
            {
                query = query.Where(peridicate);
            }
            query = ApplyIncludes(query, includes);
            if (noTracking)
            {
                query = query.AsNoTracking();
            }
            return await query.SingleOrDefaultAsync();
        }

        #endregion ::GET::

        public IQueryable<T> AsQueryable() => _entities.AsQueryable();

        #region ::HELPERS::

        private static IQueryable<T> ApplyIncludes(IQueryable<T> query, params Expression<Func<T, object>>[] includes)
        {
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }
            return query;
        }

        #endregion ::HELPERS::
    }
}
