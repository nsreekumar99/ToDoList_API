using ToDoList_API.Models;

namespace ToDoList_API.Repository.IRepository
{
	public interface IUnitOfWork
	{
		IToDoListRepository<ToDoListM> ToDoListR {  get; }
		IToDoListUpdateRepository ToDoListU { get; }
		Task SaveAsync();
	}
}
