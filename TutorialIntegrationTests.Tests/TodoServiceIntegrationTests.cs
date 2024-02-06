using Microsoft.EntityFrameworkCore;

namespace TutorialIntegrationTests.Tests;

public class TodoServiceIntegrationTests(ApiFactory apiFactory) : BaseIntegrationTest(apiFactory)
{
    public const string TestTitle = "Test Title";
    public const string TestDescription = "Test Description";

    [Fact]
    public async Task Create_ShouldCreateTodoAndReturnItsId()
    {
        // Arrange


        // Act
        var result = await _todoService.Create(TestTitle, TestDescription);

        // Assert
        var todo = await _dbContext.Todos.FirstOrDefaultAsync(x => x.Id == result);
        Assert.NotNull(todo);
        Assert.False(todo.Done);
        Assert.Equal(TestTitle, todo.Title);
        Assert.Equal(TestDescription, todo.Description);
    }

    [Fact]
    public async Task GetById_WhenTodoExists_ShouldReturnTodo()
    {
        // Arrange
        var todo = TodoTestSeed.GetTodo();
        await _dbContext.Todos.AddAsync(todo);
        await _dbContext.SaveChangesAsync();

        // Act
        var result = await _todoService.GetById(todo.Id);

        // Assert
        Assert.False(result.Done);
        Assert.Equal(todo, result);
    }

    [Fact]
    public async Task GetById_WhenTodoDoesNotExist_ShouldReturnNull()
    {
        // Arrange
        var todoId = "dfdsfuhsdiufhsd";

        // Act
        var result = await _todoService.GetById(todoId);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task GetAll_ShouldReturnTodoList()
    {
        // Arrange
        var todos = TodoTestSeed.GetTodos(4);
        await _dbContext.Todos.AddRangeAsync(todos);
        await _dbContext.SaveChangesAsync();

        // Act
        var result = await _todoService.GetAll();

        // Assert
        Assert.NotEmpty(result);
        foreach (var todo in todos)
        {
            Assert.Contains(todo, result);
        }
    }
}
