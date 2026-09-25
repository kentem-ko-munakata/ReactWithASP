using Microsoft.EntityFrameworkCore;
using ReactWithASP.Server.Models;

namespace ReactWithASP.Server.Repositories;

public class TodoRepository(TodoContext context) : ITodoRepository
{
  public async Task<IReadOnlyList<TodoItem>> GetTodos()
  {
    var todos = await context.TodoItems
    .AsTracking().
    ToListAsync();

    return todos.
    OrderByDescending(todo => todo.CreatedAt).
    ToList();
  }
}
