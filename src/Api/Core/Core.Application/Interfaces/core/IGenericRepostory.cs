using Core.Domain.Bases;
using System.Linq.Expressions;

namespace Core.Application.Interfaces.core
{
	public interface IGenericRepostory<T> where T : BaseEntity<int>
	{
		#region ::ASYNC::

		Task<IQueryable<T>> GetAllAsync();

		Task<int> AddAsync(T entity);

		Task<int> AddRagneAsync(IEnumerable<T> entities);

		Task<int> UpdateAsync(T entity);

		Task<int> UpdateRagneAsync(IEnumerable<T> entities);

		Task<int> DeleteAsync(int id);

		Task<int> DeleteAsync(T entity);

		Task<bool> DeleteRangeAsync(Expression<Func<T, bool>> perdicate);

		#endregion ::ASYNC::

		#region ::SYNC::

		IQueryable<T> GetAll();

		int Add(T entity);

		int AddRagne(IEnumerable<T> entities);

		int Update(T entity);

		int UpdateRagne(IEnumerable<T> entities);

		int Delete(T entity);

		int Delete(int id);

		T GetById(int id);

		bool DeleteRange(Expression<Func<T, bool>> perdicate);

		#endregion ::SYNC::

		#region ::ADDORUPDATE::

		Task<int> AddOrUpdateAsync(T entity);

		int AddOrUpdate(T entity);

		#endregion ::ADDORUPDATE::

		#region ::GET::

		IQueryable<T> AsQueryable();

		Task<List<T>> GetAll(bool noTracking = true);

		Task<List<T>> GetList(Expression<Func<T, bool>> peridicate, bool noTracking = true, IOrderedQueryable<T> order = null, params Expression<Func<T, object>>[] includes);

		Task<T> GetByIdAsync(int id, bool noTracking = true, params Expression<Func<T, object>>[] includes);

		Task<T> GetSingleAsync(Expression<Func<T, bool>> peridicate, bool noTracking = true, params Expression<Func<T, object>>[] includes);

		IQueryable<T> Get(Expression<Func<T, bool>> peridicate, bool noTracking = true, params Expression<Func<T, object>>[] includes);

		#endregion ::GET::

		#region ::Bulk::

		Task BulkDeleteById(IEnumerable<int> Id);

		Task BulkDelete(Expression<Func<T, bool>> peridicat);

		Task BulkDelete(IEnumerable<T> entitys);

		Task BulkUpdate(IEnumerable<T> entitys);

		Task BulkAdd(IEnumerable<T> entitys);

		#endregion ::Bulk::
	}
}
