using System.ComponentModel.DataAnnotations;

namespace ReactWithASP.Server.Models
{
    /// <summary>Todo を表します。</summary>
    public class TodoItem
    {
        /// <summary>Todo の一意な ID。</summary>
        [Required]
        public string Id { get; set; } = "";

        /// <summary>Todo のタイトル。</summary>
        [Required, MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        /// <summary>Todo が完了しているかどうか。</summary>
        public bool IsCompleted { get; set; }

        /// <summary>Todo の作成日時（UTC）。</summary>
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

        /// <summary>Todo の最終更新日時。</summary>
        public DateTimeOffset UpdatedAt { get; set; }
    }
}