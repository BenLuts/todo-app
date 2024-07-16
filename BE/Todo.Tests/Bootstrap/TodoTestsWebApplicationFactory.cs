using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Todo.Tests.Bootstrap;

public class TodoTestsWebApplicationFactory<TProgram>
    : WebApplicationFactory<TProgram> where TProgram : class
{
    private readonly TestContainerFixture _testFixture;

    public TodoTestsWebApplicationFactory(TestContainerFixture testFixture)
    {
        _testFixture = testFixture;
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            //services.Remove(services.SingleOrDefault(service => typeof(DbContextOptions<ApplicationDbContext>) == service.ServiceType));
            //services.Remove(services.SingleOrDefault(service => typeof(DbConnection) == service.ServiceType));
            //services.AddDbContext<ApplicationDbContext>((_, option) => option.UseSqlServer(_connectionString));
        });
    }
}
