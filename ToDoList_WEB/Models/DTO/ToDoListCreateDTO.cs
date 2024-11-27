using System.ComponentModel.DataAnnotations;

namespace ToDoList_WEB.Models.DTO
{
	public class ToDoListCreateDTO
	{
		[Required(ErrorMessage = "Name is required.")]
		[MaxLength(30)]
		public string Name { get; set; }
		public bool? isChecked { get; set; }
		public DateOnly? CreatedDate { get; set; }
		[Required]
		public DateOnly TaskDate { get; set; }
	}
}
