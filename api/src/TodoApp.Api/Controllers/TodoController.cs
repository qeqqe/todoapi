using Microsoft.AspNetCore.Mvc;
using TodoApp.Api.Models;
using TodoApp.Api.Interfaces;

namespace TodoApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        // Get api/todo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todo>>> GetTodos()
        {
            var todos = await _todoService.GetAllTodosAsync();

            return Ok(todos);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Todo?>> GetTodo([FromRoute] int id)
        {
            var todo = await _todoService.GetTodoByIdAsync(id);
            return Ok(todo);
        }

        [HttpPost]
        public async Task<ActionResult<Todo>> CreateTodo(CreateTodoDto createDto)
        {
            var todo = await _todoService.CreateTodoAsync(createDto);
            return Ok(todo);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Todo?>> UpdateTodo(int id, UpdateTodoDto updateDto)
        {
            var todo = await _todoService.UpdateTodoAsync(id, updateDto);

            return Ok(todo);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DelelteTodo(int id)
        {
            return Ok(await _todoService.DeleteTodoAsync(id));
        }

        [HttpPut("{id}/toggle")]
        [Consumes("application/json")]

        public async Task<ActionResult<Todo?>> ToggleCompletion(int id)
        {
            var todo = await _todoService.ToggleCompletionAsync(id);

            return Ok(todo);
        }

        [HttpGet("get")]
        public ActionResult<string> get()
        {
            return Ok("hello");
        }

    }
}