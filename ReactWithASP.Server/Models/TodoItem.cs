using System.ComponentModel.DataAnnotations;

namespace ReactWithASP.Server.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        [Required, MaxLength(200)]
        public string Title { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset UpdatedAt { get; set; }
    }
}