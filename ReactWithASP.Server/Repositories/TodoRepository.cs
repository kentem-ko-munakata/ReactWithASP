using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactWithASP.Server.Models;

namespace ReactWithASP.Server.Repositories;

public class TodoRepository(TodoContext context) : ITodoRepository
{
  public async Task<IReadOnlyList<TodoItem>> GetTodos()
  {
    var todos = await context.TodoItems
        .AsNoTracking()
        .ToListAsync();
    return todos.OrderByDescending(todo => todo.CreatedAt).ToList();
  }

  public async Task<TodoItem?> GetTodo(int id)
  {
    var todo = await context.TodoItems
    .AsNoTracking()
    .FirstOrDefaultAsync(todo => todo.Id == id);
    return todo;
  }

  public async Task<TodoItem> CreateTodo(TodoItem todo)
  {
    context.TodoItems.Add(todo);
    await context.SaveChangesAsync();

    return todo;
  }

  public async Task<TodoItem?> UpdateTodo(
    int id,
    string title,
    bool isCompleted)
  {
    var todo = await context.TodoItems
        .FirstOrDefaultAsync(todo => todo.Id == id);

    if (todo is null)
    {
      return null;
    }

    todo.Title = title;
    todo.IsCompleted = isCompleted;
    todo.UpdatedAt = DateTimeOffset.UtcNow;

    await context.SaveChangesAsync();

    return todo;
  }

  public async Task<bool> DeleteTodo(int id)
  {
    var todo = await context.TodoItems
    .FirstOrDefaultAsync(todo => todo.Id == id);

    if (todo is null)
    {
      return false;
    }

    context.Remove(todo);
    await context.SaveChangesAsync();

    return true;
  }

  public async Task<bool> DeleteTodos(int[] ids)
  {
    var todos = await context.TodoItems
        .Where(todo => ids.Contains(todo.Id))
        .ToListAsync();

    if (todos.Count != ids.Length)
    {
      return false;
    }

    context.TodoItems.RemoveRange(todos);
    await context.SaveChangesAsync();

    return true;
  }

  public async Task<TodoItem?> ToggleTodo(
   int id)
  {
    var todo = await context.TodoItems
        .FirstOrDefaultAsync(todo => todo.Id == id);

    if (todo is null)
    {
      return null;
    }
    todo.IsCompleted = !todo.IsCompleted;
    todo.UpdatedAt = DateTimeOffset.UtcNow;

    await context.SaveChangesAsync();

    return todo;
  }
}