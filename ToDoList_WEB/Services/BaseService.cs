﻿using Newtonsoft.Json;
using System.Text;
using ToDoList_Utility;
using ToDoList_WEB.Models;
using ToDoList_WEB.Services.IServices;

namespace ToDoList_WEB.Services
{
    public class BaseService : IBaseService
	{

		public APIResponse ResponseModel { get; set; } // for using while dealing with response
		public IHttpClientFactory httpClient { get; set; }

		public BaseService(IHttpClientFactory httpClientFactory)
        {
			this.ResponseModel = new();
			this.httpClient = httpClientFactory;
        }

		public async Task<T> SendAsync<T>(APIRequest apiRequest)
		{
			try
			{
				var client = httpClient.CreateClient("ToDoListClient");
				HttpRequestMessage message = new HttpRequestMessage();
				message.Headers.Add("Accept", "application/json");
				message.RequestUri = new Uri(apiRequest.Url);

				if (apiRequest.Data != null)
				{
					message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),
						Encoding.UTF8, "application/json");
				}

				switch (apiRequest.ApiType)
				{
					case SD.ApiType.POST:
						message.Method = HttpMethod.Post;
						break;

					case SD.ApiType.PUT:
						message.Method = HttpMethod.Put;
						break;

					case SD.ApiType.DELETE:
						message.Method = HttpMethod.Delete;
						break;

					default:
						message.Method = HttpMethod.Get;
						break;
				}

				HttpResponseMessage apiResponse = null;
				apiResponse = await client.SendAsync(message);

				var apiContent = await apiResponse.Content.ReadAsStringAsync();

				var deserializedResponse = JsonConvert.DeserializeObject<T>(apiContent);
				return deserializedResponse;
			}
			catch(Exception e)
			{
				var dto = new APIResponse
				{
					ErrorMessages = new List<string> { Convert.ToString(e.Message) },
					isSuccess = false
				};

				var response = JsonConvert.SerializeObject(dto);
				var deserializeResponse = JsonConvert.DeserializeObject<T>(response);
				return deserializeResponse;
			}
			
		
		}
	}
}
