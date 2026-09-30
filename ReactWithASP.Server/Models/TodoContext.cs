using Microsoft.EntityFrameworkCore;

namespace ReactWithASP.Server.Models;

public class TodoContext(DbContextOptions<TodoContext> options)
    : DbContext(options)
{
    public DbSet<TodoItem> TodoItems => Set<TodoItem>();
}