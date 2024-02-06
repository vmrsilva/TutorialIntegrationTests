
using Microsoft.EntityFrameworkCore;

namespace TutorialIntegrationTests.API;

public class TodoService(TodoContext context) : ITodoService
{
    private readonly TodoContext _context = context;

    public async Task<string> Create(string title, string description)
    {
        var todo = new Todo(title, description);
        await _context.AddAsync(todo);
        await _context.SaveChangesAsync();
        return todo.Id;
    }

    public async Task<List<Todo>> GetAll()
    {
        return await _context.Todos.OrderBy(x => x.CreatedAt).ToListAsync();
    }

    public async Task<Todo> GetById(string id)
    {
        return await _context.Todos.FirstOrDefaultAsync(x => x.Id == id);
    }
}
