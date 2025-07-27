using TodoApp.Api.Models;

namespace TodoApp.Api.Services
{
    public interface ITodoService
    {
        Task<IEnumerable<Todo>> GetAllTodosAsync();
        Task<Todo?> GetTodoByIdAsync(int id);
        Task<Todo> CreateTodoAsync(CreateTodoDto createTodo);
        Task<Todo?> UpdateTodoAsync(UpdateTodoDto updateTodo);
        Task<bool> DeleteTodoAsync(int id);
        Task<Todo?> ToggleCompletionAsync(int id);
    }
}