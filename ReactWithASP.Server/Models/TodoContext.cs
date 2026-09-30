using Microsoft.EntityFrameworkCore;

namespace ReactWithASP.Server.Models;

public class TodoContext(DbContextOptions<TodoContext> options)
    : DbContext(options)
{
    public DbSet<TodoItem> TodoItems => Set<TodoItem>();

    // todosコンテナへの割り当ておよびパーティションキーの設定
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<TodoItem>()
            .ToContainer("todos")
            .HasPartitionKey(todo => todo.Id);
    }
}