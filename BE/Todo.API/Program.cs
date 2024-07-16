using Todo.Application.Common.DependencyResolution;

namespace Todo.API;

public class Program
{
    protected Program() { }

    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.AddServiceDefaults();

        builder.Services.AddApplicationLayer();
        builder.Services.AddExceptionHandler<GracefullExceptionWrapper>();

        builder.Services.AddControllers();

        var app = builder.Build();

        app.MapDefaultEndpoints();

        // Configure the HTTP request pipeline.

        app.UseHttpsRedirection();

        app.UseAuthorization();
        app.UseExceptionHandler(o => { });

        app.MapControllers();

        app.Run();
    }
}
