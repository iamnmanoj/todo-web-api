using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Models;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options) : base(options)
    {

    }

    public DbSet<ChethanTodoItem> ChethanTodoItems { get; set; } = null!;
    public DbSet<JagadishTodoItem> JagadishTodoItems { get; set; } = null!;
    public DbSet<YeswanthTodoItem> YeswanthTodoItems { get; set; } = null!;
    public DbSet<TodoApi.Models.ChethanTodoItem> ChethanTodoItem { get; set; } = default!;
    public DbSet<TodoApi.Models.JagadishTodoItem> JagadishTodoItem { get; set; } = default!;
    public DbSet<TodoApi.Models.YeswanthTodoItem> YeswanthTodoItem { get; set; } = default!;
}