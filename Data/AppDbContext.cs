using Microsoft.EntityFrameworkCore;
using TodosApp.Models;

namespace TodosApp.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }
    public DbSet<Todo> Todos { get; set; } = default!;

}