using TodoApp.Api.Models;

namespace TodoApp.Api.Services
{
    public class TodoService : ITodoService
    {
        private readonly List<Todo> _todos = new();
        private int _nextid = 1;

        public async Task<IEnumerable<Todo>> GetAllTodosAsync()
        {
            await Task.Delay(1);
            return _todos.OrderByDescending(t => t.CreatedAt);
        }

        public async Task<Todo?> GetTodoByIdAsync(int id)
        {
            await Task.Delay(1);
            return _todos.Find(t => t.Id == id);
        }

        public async Task<Todo> CreateTodoAsync(CreateTodoDto createDto)
        {
            await Task.Delay(1);
            var todo = new Todo
            {
                Id = _nextid++,
                Title = createDto.Title,
                Description = createDto.Description,
                IsCompleted = false,
                CreatedAt = DateTime.UtcNow
            };
            _todos.Add(todo);
            return todo;
        }

        public async Task<Todo?> UpdateTodoAsync(int id, UpdateTodoDto updateDto)
        {
            await Task.Delay(1);
            // this is the references of the object in _todos with the Id = id, not a copy of that value.
            var todo = _todos.Find(t => t.Id == id);
            if (todo == null) return null;
            todo.Title = updateDto.Title;
            todo.Description = updateDto.Description;

            todo.IsCompleted = (!todo.IsCompleted && updateDto.IsCompleted) ? true : false;
            todo.CompletedAt = (!todo.IsCompleted && updateDto.IsCompleted) ? DateTime.UtcNow : null;

            return todo;
        }

        public async Task<bool> DeleteTodoAsync(int id)
        {
            await Task.Delay(1);
            var todo = _todos.Find(t => t.Id == id);
            if (todo == null) return false;

            _todos.Remove(todo);

            return true;
        }

        public async Task<Todo?> ToggleCompletionAsync(int id)
        {
            await Task.Delay(1);

            var todo = _todos.Find(t => t.Id == id);
            if (todo == null) return null;

            todo.IsCompleted = !todo.IsCompleted;
            todo.CompletedAt = todo.IsCompleted ? DateTime.UtcNow : null;
            return todo;
        }    
    }
}