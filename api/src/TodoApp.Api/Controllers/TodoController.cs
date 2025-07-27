using Microsoft.AspNetCore.Mvc;

namespace TodoApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetID(int id)
        {
            return Ok(id);
        }
    }
}