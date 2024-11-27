using Microsoft.EntityFrameworkCore;
using ToDoList_API.Data;
using ToDoList_API.Models;
using ToDoList_API.Repository.IRepository;

namespace ToDoList_API.Repository
{
	public class ToDoListUpdateRepository : ToDoListRepository<ToDoListM>, IToDoListUpdateRepository
	{
		private readonly ApplicationDbContext _db;
		public ToDoListUpdateRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public async Task<ToDoListM> UpdateAsync(ToDoListM entity)
		{
			_db.Update(entity);

			return await Task.FromResult(entity);
		}
	}
}
