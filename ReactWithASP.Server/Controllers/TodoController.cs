using Microsoft.AspNetCore.Mvc;
using ReactWithASP.Server.Application;
using ReactWithASP.Server.Models;

namespace ReactWithASP.Server.Controllers;

/// <summary>Todo を管理する API を提供します。</summary>
[ApiController]
[Route("api/[controller]")]
public class TodoController(ITodoApplication application) : ControllerBase
{
  /// <summary>Todo の一覧を取得します。</summary>
  /// <response code="200">Todo の一覧を返します。</response>
  [HttpGet]
  public async Task<ActionResult<IReadOnlyList<TodoItem>>> GetTodos()
  {
    var todos = await application.GetTodos();
    return Ok(todos);
  }

  /// <summary>指定した ID の Todo を取得します。</summary>
  /// <param name="id">取得する Todo の ID。</param>
  /// <response code="200">指定した Todo を返します。</response>
  /// <response code="404">指定した ID の Todo が存在しません。</response>
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

  /// <summary>Todo を新規作成します。</summary>
  /// <param name="request">作成する Todo の内容。</param>
  /// <response code="201">作成した Todo を返します。</response>
  /// <response code="400">リクエストが無効です。</response>
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

  /// <summary>指定した ID の Todo を更新します。</summary>
  /// <param name="id">更新する Todo の ID。</param>
  /// <param name="request">更新する Todo の内容。</param>
  /// <response code="200">更新した Todo を返します。</response>
  /// <response code="400">リクエストが無効です。</response>
  /// <response code="404">指定した ID の Todo が存在しません。</response>
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

  /// <summary>指定した ID の Todo を削除します。</summary>
  /// <param name="id">削除する Todo の ID。</param>
  /// <response code="204">Todo を削除しました。</response>
  /// <response code="404">指定した ID の Todo が存在しません。</response>
  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteTodo(int id)
  {
    var todo = await application.DeleteTodo(id);

    if (todo is false)
    {
      return NotFound();
    }

    return NoContent();
  }

}