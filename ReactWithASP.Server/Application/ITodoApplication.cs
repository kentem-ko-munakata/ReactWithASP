using ReactWithASP.Server.Models;

namespace ReactWithASP.Server.Application;

public interface ITodoApplication
{
  Task<IReadOnlyList<TodoItem>> GetTodos();
  Task<TodoItem?> GetTodo(long id);
  Task<TodoItem> CreateTodo(CreateTodoRequest request);
}