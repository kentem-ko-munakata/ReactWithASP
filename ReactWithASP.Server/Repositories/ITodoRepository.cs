using Microsoft.AspNetCore.Mvc;
using ReactWithASP.Server.Models;

namespace ReactWithASP.Server.Repositories;

public interface ITodoRepository
{
  Task<IReadOnlyList<TodoItem>> GetTodos();
  Task<TodoItem?> GetTodo(string id);
  Task<TodoItem> CreateTodo(TodoItem todo);
  Task<TodoItem?> UpdateTodo(
    string id,
    string title,
    bool isCompleted);

  Task<bool> DeleteTodo(string id);
  Task<bool> DeleteTodos(string[] ids);
  Task<TodoItem?> ToggleTodo(string id);
}