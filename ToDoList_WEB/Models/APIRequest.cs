using Microsoft.AspNetCore.Mvc;
using static ToDoList_Utility.SD;

namespace ToDoList_WEB.Models
{
	public class APIRequest
	{
		public ApiType ApiType { get; set; } = ApiType.GET;
		public string Url { get; set; }
		public object Data { get; set; }
	}
}
