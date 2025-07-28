using TodoApp.Api.Models;

namespace TodoApp.Api.Interfaces
{
    public interface ITodoRepository
    {
        Task<IEnumerable<Todo>> GetAllAsync();
        Task<Todo?> GetByIdAsync(int id);
        Task<Todo> CreateAsync(Todo todo);
        Task<Todo?> UpdateAsync(Todo todo);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Todo>> GetCompletedAsync();
        Task<IEnumerable<Todo>> GetPendingAsync();
        Task<int> GetTotalCountAsync();
    }
}
