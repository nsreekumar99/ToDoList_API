using ToDoList_Utility;
using ToDoList_WEB.Models;
using ToDoList_WEB.Models.DTO;
using ToDoList_WEB.Services.IServices;

namespace ToDoList_WEB.Services
{
	public class ToDoListService : BaseService, IToDoListService
	{
		private IHttpClientFactory _httpClientFactory;
		private string _villaUrl;
        public ToDoListService(IHttpClientFactory httpClientFactory, IConfiguration configuration) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
			_villaUrl = configuration.GetValue<String>("ServiceUrls:ToDoList_API");
        }

        public Task<T> CreateAsync<T>(ToDoListCreateDTO dto)
		{
			return SendAsync<T>(new APIRequest
			{
				ApiType = SD.ApiType.POST,
				Data = dto,
				Url = _villaUrl + "api/ToDoListAPI"
			});
		}

		public Task<T> DeleteAsync<T>(int id)
		{
			return SendAsync<T>(new APIRequest
			{
				ApiType = SD.ApiType.DELETE,
				Url = _villaUrl + "api/ToDoListAPI/" + id
			});
		}

		public Task<T> GetAllAsync<T>()
		{
			return SendAsync<T>(new APIRequest
			{
				ApiType = SD.ApiType.GET,
				Url = _villaUrl + "api/ToDoListAPI"
			});
		}

		public Task<T> GetAsync<T>(int id)
		{
			return SendAsync<T>(new APIRequest
			{
				ApiType = SD.ApiType.GET,
				Url = _villaUrl + "api/ToDoListAPI/" + id
			});
		}

		public Task<T> UpdateAsync<T>(ToDoListUpdateDTO dto)
		{
			return SendAsync<T>(new APIRequest
			{
				ApiType = SD.ApiType.PUT,
				Data = dto,
				Url = _villaUrl + "api/ToDoListAPI/" + dto.Id
			});
		}
	}
}
