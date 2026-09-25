using System.ComponentModel.DataAnnotations;

namespace ReactWithASP.Server.Application;

public class CreateTodoRequest
{
  [Required]
  [MaxLength(200)]
  public string Title { get; set; } = string.Empty;
}