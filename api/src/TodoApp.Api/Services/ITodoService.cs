using TodoApp.Api.Models;

namespace TodoApp.Api.Services
{
    public interface ITodoService
    {
        Task<IEnumerable<Todo>> GetAllTodosAsync();
        Task<Todo?> GetTodoByIdAsync(int id);
        Task<Todo> CreateTodoAsync(CreateTodoDto createDto);
        Task<Todo?> UpdateTodoAsync(int id, UpdateTodoDto updateDto);
        Task<bool> DeleteTodoAsync(int id);
        Task<Todo?> ToggleCompletionAsync(int id);
    }
}