using Microsoft.EntityFrameworkCore;

namespace ProgrammingGame.App.Models
{
    public class EntryContext : DbContext
    {
        public EntryContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Entry> Entries { get; set; }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>().HasData(new Task
            {
                TaskId = 1,
                Name = "Hello World",
                Description = "Write a program in C# that outputs 'Hello World!' to console.",
                Solution = "Hello World!"
            }, new Task
            {
                TaskId = 2,
                Name = "Test AAA",
                Description = "Write a program in C# that outputs 'AAA' to console.",
                Solution = "AAA"
            }, new Task
            {
                TaskId = 3,
                Name = "Test BBB",
                Description = "Write a program in C# that outputs 'BBB' to console.",
                Solution = "BBB"
            });
        }
    }
}
