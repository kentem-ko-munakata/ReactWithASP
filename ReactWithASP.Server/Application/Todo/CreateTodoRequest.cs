using System.ComponentModel.DataAnnotations;

namespace ReactWithASP.Server.Application;

/// <summary>Todo の新規作成に使用するリクエスト。</summary>
public class CreateTodoRequest
{
  /// <summary>Todo のタイトル。最大 200 文字です。</summary>
  [Required]
  [MaxLength(200)]
  public string Title { get; set; } = string.Empty;
}