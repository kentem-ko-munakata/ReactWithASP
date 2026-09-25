using Microsoft.AspNetCore.Mvc;
using ReactWithASP.Server.Application;
using ReactWithASP.Server.Models;

namespace ReactWithASP.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController(ITodoApplication application) : ControllerBase
{
  [HttpGet]
  public async Task<ActionResult<IReadOnlyList<TodoItem>>> GetTodos()
  {
    var todos = await application.GetTodos();
    return Ok(todos);
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<TodoItem>> GetTodo(int id)
  {
    var todo = await application.GetTodo(id);

    if (todo == null)
    {
      return NotFound();
    }
    return Ok(todo);
  }

  [HttpPost]
  public async Task<ActionResult<TodoItem>> CreateTodo(
    CreateTodoRequest request)
  {
    var todo = await application.CreateTodo(request);

    return CreatedAtAction(
        nameof(GetTodo),
        new { id = todo.Id },
        todo);
  }

  [HttpPut("{id}")]
  public async Task<ActionResult<TodoItem>> UpdateTodo(
    int id,
    UpdateTodoRequest request)
  {
    var todo = await application.UpdateTodo(id, request);

    if (todo is null)
    {
      return NotFound();
    }

    return Ok(todo);
  }

  // [HttpDelete("{id}")]
  // public async Task<IActionResult> DeleteTodo(

  // );

}