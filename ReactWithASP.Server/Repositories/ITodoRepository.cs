using ReactWithASP.Server.Models;

namespace ReactWithASP.Server.Repositories;

public interface ITodoRepository
{
  Task<IReadOnlyList<TodoItem>> GetTodos();
}