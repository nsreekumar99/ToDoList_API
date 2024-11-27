using System.Linq.Expressions;

namespace ToDoList_API.Repository.IRepository
{
	public interface IToDoListRepository<T> where T : class
	{
		Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);
		Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true);
		Task AddAsync(T entity);

		Task Remove(T entity);

		Task SaveAsync();
	}
}
