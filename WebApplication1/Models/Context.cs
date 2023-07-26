using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class Context : DbContext
    {
        public DbSet<TaskItem> TaskItems { get; set; }
        
        public Context(DbContextOptions<Context> options) : base(options) { }
    }
}