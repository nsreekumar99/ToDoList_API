using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList_API.Models
{
	public class ToDoListM
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		[MaxLength(30)]
		public string Name { get; set; }
		public bool? isChecked { get; set; }
		[Required]
		public DateOnly TaskDate { get; set; }
		public DateOnly? CreatedDate { get; set; }
		public DateOnly? UpdatedDate { get; set; }
	}
}
