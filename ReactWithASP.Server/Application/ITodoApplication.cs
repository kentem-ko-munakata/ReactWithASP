using ReactWithASP.Server.Models;

namespace ReactWithASP.Server.Application;

public interface ITodoApplication
{
  Task<IReadOnlyList<TodoItem>> GetTodos();
  Task<TodoItem?> GetTodo(int id);
  Task<TodoItem> CreateTodo(CreateTodoRequest request);
  Task<TodoItem?> UpdateTodo(
    int id,
    UpdateTodoRequest request);
}