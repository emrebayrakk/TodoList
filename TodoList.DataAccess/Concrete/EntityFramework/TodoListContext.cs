using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoList.Entities.Concrete;

namespace TodoList.DataAccess.Concrete.EntityFramework
{
    public class TodoListContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=TodoListDb;Integrated Security=True");
            }

            public DbSet<Note> Notes { get; set; }
            public DbSet<User> Users { get; set; }
        
    }
}
