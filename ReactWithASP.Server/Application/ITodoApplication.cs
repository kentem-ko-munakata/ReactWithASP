using ReactWithASP.Server.Models;

namespace ReactWithASP.Server.Application;

public interface ITodoApplication
{
  Task<IReadOnlyList<TodoItem>> GetTodos();
}