using Microsoft.AspNetCore.Mvc;
using ReactWithASP.Server.Application;
using ReactWithASP.Server.Contracts.Todo;
using ReactWithASP.Server.Models;

namespace ReactWithASP.Server.Controllers;

/// <summary>Todo を管理する API を提供します。</summary>
[ApiController]
[Route("api/[controller]")]
public class TodoController(ITodoApplication application) : ControllerBase
{
    /// <summary>Todo の一覧を取得</summary>
    /// <response code="200">Todo の一覧を返却</response>
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<TodoItem>>> GetTodos()
    {
        var todos = await application.GetTodos();
        return Ok(todos);
    }

    /// <summary>指定した ID の Todo を取得</summary>
    /// <param name="id">取得する Todo の ID</param>
    /// <response code="200">指定した Todo を返却</response>
    /// <response code="404">指定した ID の Todo が存在しない</response>
    [HttpGet("{id}")]
    public async Task<ActionResult<TodoItem>> GetTodo(string id)
    {
        var todo = await application.GetTodo(id);

        if (todo == null)
        {
            return NotFound();
        }
        return Ok(todo);
    }

    /// <summary>Todo を新規作成</summary>
    /// <param name="request">作成する Todo の内容</param>
    /// <response code="201">作成した Todo を返却</response>
    /// <response code="400">リクエストが無効</response>
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

    /// <summary>指定した ID の Todo を更新</summary>
    /// <param name="id">更新する Todo の ID</param>
    /// <param name="request">更新する Todo の内容</param>
    /// <response code="200">更新した Todo を返却</response>
    /// <response code="400">リクエストが無効</response>
    /// <response code="404">指定した ID の Todo が存在しない</response>
    [HttpPut("{id}")]
    public async Task<ActionResult<TodoItem>> UpdateTodo(
      string id,
      UpdateTodoRequest request)
    {
        var todo = await application.UpdateTodo(id, request);

        if (todo is null)
        {
            return NotFound();
        }

        return Ok(todo);
    }

    /// <summary>指定した ID の Todo を削除</summary>
    /// <param name="id">削除する Todo の ID</param>
    /// <response code="204">Todo を削除</response>
    /// <response code="404">指定した ID の Todo が存在しない</response>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodo(string id)
    {
        var todo = await application.DeleteTodo(id);

        if (todo is false)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>指定した ID の Todo を一括削除</summary>
    /// <response code="204">Todo を削除</response>
    /// <response code="400">ID の一覧が空、または無効</response>
    /// <response code="404">指定した ID の Todo が存在しない</response>
    [HttpDelete("bulk")]
    public async Task<IActionResult> DeleteTodos(DeleteTodosRequest request)
    {
        if (request.Ids is null || request.Ids.Length == 0)
        {
            return BadRequest();
        }

        // 対象Todoが見つからない場合
        if (!await application.DeleteTodos(request.Ids))
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>指定した ID の Todo のステータス更新</summary>
    /// <param name="id">更新する Todo の ID</param>
    /// <response code="200">更新した Todo を返却</response>
    /// <response code="404">指定した ID の Todo が存在しない</response>
    [HttpPost("{id}/toggle")]
    public async Task<ActionResult<TodoItem>> ToggleTodo(string id)
    {
        var todo = await application.ToggleTodo(id);

        if (todo is null)
        {
            return NotFound();
        }

        return Ok(todo);
    }

}