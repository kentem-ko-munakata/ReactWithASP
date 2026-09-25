using ReactWithASP.Server.Models;

namespace ReactWithASP.Server.Repositories;

public interface ITodoRepository
{
  Task<IReadOnlyList<TodoItem>> GetTodos();
  Task<TodoItem?> GetTodo(long id);
  Task<TodoItem> CreateTodo(TodoItem todo);
  Task<TodoItem?> UpdateTodo(
    int id,
    string title,
    bool isCompleted);
}