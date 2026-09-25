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
}