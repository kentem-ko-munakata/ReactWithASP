using ReactWithASP.Server.Contracts.Todo;
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

  public Task<TodoItem?> GetTodo(string id)
  {
    return repository.GetTodo(id);
  }

  public Task<TodoItem> CreateTodo(CreateTodoRequest request)
  {
    var todo = new TodoItem
    {
      Id = Guid.NewGuid().ToString(),
      Title = request.Title.Trim(),
      IsCompleted = false,
      CreatedAt = DateTimeOffset.UtcNow,
      UpdatedAt = DateTimeOffset.UtcNow
    };

    return repository.CreateTodo(todo);
  }

  public Task<TodoItem?> UpdateTodo(
    string id,
    UpdateTodoRequest request)
  {
    return repository.UpdateTodo(
        id,
        request.Title.Trim(),
        request.IsCompleted);
  }

  public Task<bool> DeleteTodo(string id)
  {
    return repository.DeleteTodo(id);
  }

  public Task<bool> DeleteTodos(string[] ids)
  {
    var distinctIds = ids.Distinct().ToArray();
    return repository.DeleteTodos(distinctIds);
  }

  public Task<TodoItem?> ToggleTodo(
    string id)
  {
    return repository.ToggleTodo(
        id);
  }
}