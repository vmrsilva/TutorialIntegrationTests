namespace TutorialIntegrationTests.API;

public class Todo
{
    public Todo()
    {
    }

    public Todo(string title, string description)
    {
        Title = title;
        Description = description;
        Id = Guid.NewGuid().ToString().Replace("-", "");
        CreatedAt = DateTime.UtcNow;
        Done = false;
    }

    public string Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool Done { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
}
