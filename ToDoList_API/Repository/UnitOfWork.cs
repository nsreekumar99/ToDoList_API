using ToDoList_API.Data;
using ToDoList_API.Models;
using ToDoList_API.Repository.IRepository;

namespace ToDoList_API.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _db;

		public IToDoListRepository<ToDoListM> ToDoListR { get; private set; }
		public IToDoListUpdateRepository ToDoListU { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
			ToDoListR = new ToDoListRepository<ToDoListM>(_db); // initialize Todolist repository
			ToDoListU = new ToDoListUpdateRepository(_db);
        }

		public async Task SaveAsync()
		{
			await _db.SaveChangesAsync();
		}
	}
}
