using Microsoft.EntityFrameworkCore;
using Todo.API.Models;

namespace Todo.API.Data
{
    public class TodoAppDbContext: DbContext 
    {
        public TodoAppDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {
            
        }


        public DbSet<Todos> todoLists { get; set; }
    }
}
