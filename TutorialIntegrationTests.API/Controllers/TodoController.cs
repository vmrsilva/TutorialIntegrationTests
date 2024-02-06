using Microsoft.AspNetCore.Mvc;

namespace TutorialIntegrationTests.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoController(ITodoService todoService) : ControllerBase
{
    private readonly ITodoService _todoService = todoService;

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTodoModel model)
    {
        var result = await _todoService.Create(model.Title, model.Description);
        return CreatedAtRoute(nameof(GetById), routeValues: new { Id = result }, result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var todos = await _todoService.GetAll();
        return Ok(todos);
    }

    [HttpGet("{id}", Name = "GetById")]
    public async Task<IActionResult> GetById(string id)
    {
        var todo = await _todoService.GetById(id);
        return Ok(todo);
    }
}
