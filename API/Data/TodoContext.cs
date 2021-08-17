using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class TodoContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
        }
    }
}