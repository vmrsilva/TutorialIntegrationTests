namespace TutorialIntegrationTests.API;

public interface ITodoService
{
    Task<Todo> GetById(string id);
    Task<List<Todo>> GetAll();
    Task<string> Create(string title, string description);
}
