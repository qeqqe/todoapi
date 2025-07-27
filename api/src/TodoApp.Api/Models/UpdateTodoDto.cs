using System.ComponentModel.DataAnnotations;

namespace TodoApp.Api.Models
{
    public class UpdateTodoDto
    {

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }

        [Required]
        public bool IsCompleted { get; set; }
    }
}