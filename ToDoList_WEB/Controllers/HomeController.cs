using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using ToDoList_WEB.Models;
using ToDoList_WEB.Models.DTO;
using ToDoList_WEB.Services;
using ToDoList_WEB.Services.IServices;

namespace ToDoList_WEB.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IToDoListService _ToDoListService;
		private IMapper _mapper;

		public HomeController(ILogger<HomeController> logger, IMapper mapper, IToDoListService toDoListService)
		{
			_logger = logger;
			_ToDoListService = toDoListService;
			_mapper = mapper;
		}
		
		public async Task<List<ToDoListMDTO>> GetAllAsync()
		{
			List<ToDoListMDTO> list = new();
			var response = await _ToDoListService.GetAllAsync<APIResponse>();
			if (response != null && response.isSuccess)
			{
				list = JsonConvert.DeserializeObject<List<ToDoListMDTO>>(Convert.ToString(response.Result));
			}
			return list;
		}

		public async Task<IActionResult> Index()
		{
			var list = await GetAllAsync();
			return View(list);
		}

		[HttpPost]
		public async Task<IActionResult> PostTestData([FromBody] ToDoListUpdateDTO dto)
		{
			if (ModelState.IsValid)
			{
				dto.UpdatedDate = DateOnly.FromDateTime(DateTime.Now);
				var response = await _ToDoListService.UpdateAsync<APIResponse>(dto);
				if (response != null && response.isSuccess)
				{
					return Json(new { success = true, Message = "Data updated successfully!" });
				}
			}
			return Json(new { success = false, Message = "Failed to update data." });
		}

		[HttpPost]
		public async Task<ActionResult> CreateNewTask([FromBody] ToDoListCreateDTO dto)
		{
			if (dto == null)
			{
				return Json(new { success = false, errors = new[] { "Invalid data provided. Please ensure all fields are filled out correctly." } });
			}

			// Validate the model state for specific property errors
			if (!ModelState.IsValid)
			{
				var modelErrors = ModelState.Values
					.SelectMany(v => v.Errors)
					.Select(e => e.ErrorMessage)
					.ToList();

				return Json(new { success = false, modelErrors });
			}

			if (ModelState.IsValid)
			{
				dto.CreatedDate = DateOnly.FromDateTime(DateTime.Now);
				var response = await _ToDoListService.CreateAsync<APIResponse>(dto);
				if(response !=null && response.isSuccess) 
				{
					var createdTask = JsonConvert.DeserializeObject<ToDoListMDTO>(Convert.ToString(response.Result));

					return Json(new
					{
						success = true,
						Message = "Data updated successfully!",
						data = new
						{
							id = createdTask.Id,
							name = createdTask.Name,
							taskDate = createdTask.TaskDate.ToString("yyyy-MM-dd")
						}
					});
				}

				if(response.ErrorMessages!= null && response.ErrorMessages.Any())
				{
					return Json(new
					{
						success = false,
						errors = response.ErrorMessages
					});
				}

				return Json(new { success = false, Message = "Coundn't update data!" });
			}
			return Json(new { success = false, message = "Failed to create the task. Please try again." });
		}

		[HttpPost]
		public IActionResult DeleteTask(int id)
		{
			var response = _ToDoListService.GetAsync<APIResponse>(id);

			if(response != null)
			{
				var delete = _ToDoListService.DeleteAsync<APIResponse>(id);

				if(delete != null)
				{
					return Json(new { success = true, Message = "Task Deleted Successfully" });
				}
				return NotFound();
			}
			return NotFound();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
