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
    }
}
