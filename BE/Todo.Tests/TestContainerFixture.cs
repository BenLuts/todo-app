using Microsoft.AspNetCore.Mvc.Testing;
using Testcontainers.CosmosDb;
using Todo.API;

namespace Todo.Tests;

public sealed class TestContainerFixture : IAsyncLifetime
{
    private readonly CosmosDbContainer _cosmosDbContainer = new CosmosDbBuilder()
        .Build();

    public Task InitializeAsync()
    {
        return _cosmosDbContainer.StartAsync();
    }

    public Task DisposeAsync()
    {
        return _cosmosDbContainer.DisposeAsync().AsTask();
    }

    public abstract class TestBase : IClassFixture<TestContainerFixture>, IDisposable
    {
        private readonly WebApplicationFactory<Program> _webApplicationFactory;

        protected TestBase(TestContainerFixture fixture)
        {
            _webApplicationFactory = new TodoTestsWebApplicationFactory<Program>(fixture);
        }

        public HttpClient GetApiClient()
        {
            return _webApplicationFactory.CreateClient();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                _webApplicationFactory.Dispose();
        }
    }
}
