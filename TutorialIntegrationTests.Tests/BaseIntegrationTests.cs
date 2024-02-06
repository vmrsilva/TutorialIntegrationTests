using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using TutorialIntegrationTests.API;

namespace TutorialIntegrationTests.Tests;

public class BaseIntegrationTest : IClassFixture<ApiFactory>, IDisposable
{
    private readonly IServiceScope _scope;
    protected readonly JsonSerializerOptions _jsonSerializerOptions;
    protected readonly ITodoService _todoService;
    protected readonly TodoContext _dbContext;

    protected BaseIntegrationTest(ApiFactory apiFactory)
    {
        _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        _scope = apiFactory.Services.CreateScope();
        _dbContext = _scope.ServiceProvider.GetRequiredService<TodoContext>();
        _todoService = _scope.ServiceProvider.GetRequiredService<ITodoService>();
    }

    public void Dispose()
    {
        _scope?.Dispose();
    }
}
