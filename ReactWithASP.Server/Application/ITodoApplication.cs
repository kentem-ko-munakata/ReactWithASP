using ReactWithASP.Server.Contracts.Todo;
using ReactWithASP.Server.Models;

namespace ReactWithASP.Server.Application;

public interface ITodoApplication
{
  Task<IReadOnlyList<TodoItem>> GetTodos();
  Task<TodoItem?> GetTodo(string id);
  Task<TodoItem> CreateTodo(CreateTodoRequest request);
  Task<TodoItem?> UpdateTodo(
    string id,
    UpdateTodoRequest request);
  Task<bool> DeleteTodo(string id);
  Task<bool> DeleteTodos(string[] ids);
  Task<TodoItem?> ToggleTodo(
    string id
  );
}