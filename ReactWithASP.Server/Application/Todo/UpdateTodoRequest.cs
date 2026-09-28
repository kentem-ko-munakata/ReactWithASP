using System.ComponentModel.DataAnnotations;

namespace ReactWithASP.Server.Application;

/// <summary>Todo の更新に使用するリクエスト。</summary>
public class UpdateTodoRequest
{
  /// <summary>Todo のタイトル。最大 200 文字です。</summary>
  [Required]
  [MaxLength(200)]
  public string Title { get; set; } = string.Empty;

  /// <summary>Todo が完了しているかどうか。</summary>
  public bool IsCompleted { get; set; }
}