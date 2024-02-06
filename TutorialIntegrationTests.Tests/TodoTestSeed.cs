using TutorialIntegrationTests.API;

namespace TutorialIntegrationTests.Tests;

public static class TodoTestSeed
{
    public static Todo GetTodo(string title = "title", string description = "description")
    {
        return new Todo(title, description);
    }

    public static List<Todo> GetTodos(int quantity = 1)
    {
        var todos = new List<Todo>();
        for (var i = 0; i < quantity; i++)
        {
            todos.Add(GetTodo());
        }
        return todos;
    }
}
