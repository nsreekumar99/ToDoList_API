﻿using System.Net;

namespace ToDoList_WEB.Models
{
	public class APIResponse
	{
		public HttpStatusCode StatusCode {  get; set; }
		public bool isSuccess { get; set; }
		public List<string> ErrorMessages { get; set; }
		public object Result { get; set; }
	}
}
