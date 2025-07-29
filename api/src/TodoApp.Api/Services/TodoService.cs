
using TodoApp.Api.Interfaces;
using TodoApp.Api.Models;

namespace TodoApp.Api.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _repository;

        public TodoService(ITodoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Todo>> GetAllTodosAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Todo?> GetTodoByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Todo> CreateTodoAsync(CreateTodoDto createDto)
        {
            var todo = new Todo
            {
                Title = createDto.Title,
                Description = createDto.Description,
                IsCompleted = false
            };
            return await _repository.CreateAsync(todo);
        }

        public async Task<Todo?> UpdateTodoAsync(int id, UpdateTodoDto updateDto)
        {
        var todo = new Todo
            {
                Id = id,
                Title = updateDto.Title,
                Description = updateDto.Description,
                IsCompleted = updateDto.IsCompleted
            };
            return await _repository.UpdateAsync(todo);
        }

        public async Task<bool> DeleteTodoAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<Todo?> ToggleCompletionAsync(int id)
        {
            var todo = await _repository.GetByIdAsync(id);

            if (todo == null) return null;

            var updateDto = new UpdateTodoDto
            {
                Title = todo.Title,
                Description = todo.Description,
                IsCompleted = !todo.IsCompleted
            };

            return await UpdateTodoAsync(id, updateDto);
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _repository.GetTotalCountAsync(); 
        }
    }
}