namespace TutorialIntegrationTests.API;

public class CreateTodoModel
{
    public CreateTodoModel()
    {
    }

    public CreateTodoModel(string title, string description)
    {
        Title = title;
        Description = description;
    }

    public string Title { get; set; }
    public string Description { get; set; }
}
