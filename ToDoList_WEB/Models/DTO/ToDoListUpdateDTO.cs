using System.ComponentModel.DataAnnotations;

namespace ToDoList_WEB.Models.DTO
{
	public class ToDoListUpdateDTO
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(30)]
		public string Name { get; set; }
		public bool? isChecked { get; set; }
		public DateOnly? UpdatedDate { get; set; }
		public DateOnly? TaskDate { get; set; }
	}
}
