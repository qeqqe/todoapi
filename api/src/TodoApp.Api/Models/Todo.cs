using System.ComponentModel.DataAnnotations;

namespace TodoApp.Api.Models
{
    public class Todo
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;
        
        [MaxLength(1000)]
        public string? Description { get; set; }
        
        public bool IsCompleted { get; set; }
        
        public DateTime CreatedAt { get; set; }
        
        public DateTime? CompletedAt { get; set; }
        
        public TimeSpan? CompletionTime => CompletedAt?.Subtract(CreatedAt);
    }
}
