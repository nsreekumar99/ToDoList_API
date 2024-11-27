using System.ComponentModel.DataAnnotations;

namespace ToDoList_API.Models.DTO
{
	public class ToDoListMDTO
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(30)]
		public string Name { get; set; }
		public bool? isChecked { get; set; }
		public DateOnly? CreatedDate { get; set; }
		[Required]
		public DateOnly TaskDate { get; set; }


	}
}
