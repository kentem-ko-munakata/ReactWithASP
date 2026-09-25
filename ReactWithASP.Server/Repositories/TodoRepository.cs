using Microsoft.EntityFrameworkCore;
using ReactWithASP.Server.Models;

namespace ReactWithASP.Server.Repositories;

public class TodoRepository(TodoContext context) : ITodoRepository
{
  public async Task<IReadOnlyList<TodoItem>> GetTodos()
  {
    var todos = await context.TodoItems
        .AsNoTracking()
        .ToListAsync();

    return todos
        .OrderByDescending(todo => todo.CreatedAt)
        .ToList();
  }

  public async Task<TodoItem?> GetTodo(long id)
  {
    return await context.TodoItems
        .AsNoTracking()
        .FirstOrDefaultAsync(todo => todo.Id == id);
  }

  public async Task<TodoItem> CreateTodo(TodoItem todo)
  {
    context.TodoItems.Add(todo);
    await context.SaveChangesAsync();

    return todo;
  }
}