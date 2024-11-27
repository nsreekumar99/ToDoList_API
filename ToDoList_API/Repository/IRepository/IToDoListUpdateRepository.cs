using ToDoList_API.Models;

namespace ToDoList_API.Repository.IRepository
{
	public interface IToDoListUpdateRepository : IToDoListRepository<ToDoListM>
	{
		Task<ToDoListM> UpdateAsync(ToDoListM entity);
	}
}
