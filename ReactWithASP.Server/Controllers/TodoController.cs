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
}