using ToDoList_WEB.Models.DTO;

namespace ToDoList_WEB.Services.IServices
{
	public interface IToDoListService
	{
		Task<T> GetAllAsync<T>();
		Task<T> GetAsync<T>(int id);
		Task<T> CreateAsync<T>(ToDoListCreateDTO dto);
		Task<T> UpdateAsync<T>(ToDoListUpdateDTO dto);
		Task<T> DeleteAsync<T>(int id);

	}
}
