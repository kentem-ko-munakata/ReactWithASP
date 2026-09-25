using System.ComponentModel.DataAnnotations;

namespace ReactWithASP.Server.Application;

public class UpdateTodoRequest
{
  [Required]
  [MaxLength(200)]
  public string Title { get; set; } = string.Empty;

  public bool IsCompleted { get; set; }
}