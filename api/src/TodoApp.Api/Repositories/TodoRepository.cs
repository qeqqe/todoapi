using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoApp.Api.Data;
using TodoApp.Api.Interfaces;
using TodoApp.Api.Models;

namespace TodoApp.Api.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoDbContext _context;

        public TodoRepository(TodoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Todo>> GetAllAsync()
        {
            return await _context.Todos
            .AsTracking()
            .OrderByDescending(t => t.CreatedAt)
            .ToListAsync();
        }

        public async Task<Todo?> GetByIdAsync(int id)
        {
            return await _context.Todos
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Todo> CreateAsync(Todo todo)
        {
            todo.CreatedAt = DateTime.UtcNow;
            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();
            return todo;
        }

        public async Task<Todo?> UpdateAsync(Todo todo)
        {
            var existingTodo = await _context.Todos
            .FindAsync(todo.Id);
            if (existingTodo == null) return null;


            existingTodo.Title = todo.Title;
            existingTodo.Description = todo.Description;

            if (todo.IsCompleted && !existingTodo.IsCompleted)
            {
                existingTodo.IsCompleted = true;
                existingTodo.CompletedAt = DateTime.UtcNow;
            }
            else if (!todo.IsCompleted && existingTodo.IsCompleted)
            {
                existingTodo.IsCompleted = false;
                existingTodo.CompletedAt = null;
            }
            await _context.SaveChangesAsync();
            return existingTodo;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null) return false;

            _context.Todos.Remove(todo);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Todo>> GetPendingAsync()
        {
            return await _context.Todos
            .AsNoTracking()
            .Where(t => !t.IsCompleted)
            .OrderByDescending(t => t.CreatedAt)
            .ToListAsync();
        }
        public async Task<IEnumerable<Todo>> GetCompletedAsync()
        {
            return await _context.Todos
            .AsNoTracking()
            .Where(t => t.IsCompleted).
            OrderByDescending(t => t.CreatedAt)
            .ToListAsync();
        }
        public async Task<int> GetTotalCountAsync()
        {
            return await _context.Todos.CountAsync();
        }

    }
}