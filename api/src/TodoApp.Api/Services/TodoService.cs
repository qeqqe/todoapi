using TodoApp.Api.Models;

namespace TodoApp.Api.Services
{
    public class TodoService : ITodoService
    {
        private readonly Todo _todo = new();
        private int _nextid = 1;
        public Task<Todo> CreateTodoAsync(CreateTodoDto createTodo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTodoAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Todo>> GetAllTodosAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Todo?> GetTodoByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Todo?> ToggleCompletionAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Todo?> UpdateTodoAsync(UpdateTodoDto updateTodo)
        {
            throw new NotImplementedException();
        }
    }
}