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

  public Task<TodoItem?> GetTodo(int id)
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

  public Task<TodoItem?> UpdateTodo(
    int id,
    UpdateTodoRequest request)
  {
    return repository.UpdateTodo(
        id,
        request.Title.Trim(),
        request.IsCompleted);
  }

  public Task<bool> DeleteTodo(int id)
  {
    return repository.DeleteTodo(id);
  }

  public Task<bool> DeleteTodos(int[] ids)
  {
    var distinctIds = ids.Distinct().ToArray();
    return repository.DeleteTodos(distinctIds);
  }

  public Task<TodoItem?> ToggleTodo(
    int id)
  {
    return repository.ToggleTodo(
        id);
  }
}