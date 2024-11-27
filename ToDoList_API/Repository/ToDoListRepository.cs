using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using ToDoList_API.Data;
using ToDoList_API.Repository.IRepository;

namespace ToDoList_API.Repository
{
	public class ToDoListRepository<T> : IToDoListRepository<T> where T : class
	{
		private readonly ApplicationDbContext _db;
		internal DbSet<T> _dbSet;
        public ToDoListRepository(ApplicationDbContext db)
        {
            _db = db;
			this._dbSet = _db.Set<T>();
        }

        public async Task AddAsync(T entity)
		{
			await _dbSet.AddAsync(entity);
		}

		public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null)
		{
			IQueryable<T> query = _dbSet;
			if (filter != null)
			{
				query = query.Where(filter);
			}
			return await query.ToListAsync();
		}

		public async Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true)
		{
			IQueryable<T> query = _dbSet;
			if (!tracked)
			{
				query = query.AsNoTracking();
			}
			if (filter != null)
			{
				query = query.Where(filter);
			}
			return await query.FirstOrDefaultAsync();
		}

		public async Task Remove(T entity)
		{
			_dbSet.Remove(entity);
		}

		public async Task SaveAsync()
		{
			await _db.SaveChangesAsync();
		}
	}
}
