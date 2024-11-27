using Microsoft.EntityFrameworkCore;
using ToDoList_API.Models;

namespace ToDoList_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ToDoListM>ToDoListM{get;set;}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            modelBuilder.Entity<ToDoListM>().HasData(
                new ToDoListM()
                {
                    Id = 11,
                    Name = "Test New",
                    isChecked = true,
                    TaskDate = DateOnly.ParseExact("01-12-2024", "dd-MM-yyyy"),
                    CreatedDate = DateOnly.FromDateTime(DateTime.Now)
                },
                new ToDoListM()
                {
                    Id = 12,
                    Name = "Test New 2",
                    isChecked = true,
                    TaskDate = DateOnly.ParseExact("02-12-2024", "dd-MM-yyyy"),
                    CreatedDate = DateOnly.FromDateTime(DateTime.Now)
                });
		}

	}
}
