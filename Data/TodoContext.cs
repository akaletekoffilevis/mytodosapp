using Microsoft.EntityFrameworkCore;
using TodosApp.Models;

namespace TodosApp.Data;

public class TodoContext : DbContext
{
    public DbSet<Todo> Todos { get; set; }

    public TodoContext(DbContextOptions<TodoContext> options) : base(options)
    {

    }

}