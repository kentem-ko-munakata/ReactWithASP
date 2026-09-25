using ReactWithASP.Server.Models;
using ReactWithASP.Server.Repositories;

namespace ReactWithASP.Server.Application;

public class TodoApplication(ITodoRepository repository)
    : ITodoApplication
{
  public Task<IReadOnlyList<TodoItem>> GetTodos()
  {
    return repository.GetTodos();
  }

  public Task<TodoItem?> GetTodo(long id)
  {
    return repository.GetTodo(id);
  }

  public Task<TodoItem> CreateTodo(CreateTodoRequest request)
  {
    var todo = new TodoItem
    {
      Title = request.Title.Trim(),
      IsCompleted = false,
      CreatedAt = DateTimeOffset.UtcNow,
      UpdatedAt = DateTimeOffset.UtcNow
    };

    return repository.CreateTodo(todo);
  }
}