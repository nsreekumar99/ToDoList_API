using Microsoft.AspNetCore.Mvc;

namespace ToDoList_WEB.Controllers
{
	public class ToDoListController : Controller
	{
		public IActionResult IndexToDoList()
		{
			return View();
		}
	}
}
