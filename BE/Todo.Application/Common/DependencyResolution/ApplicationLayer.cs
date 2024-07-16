using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Todo.Application.Common.DependencyResolution;
public static class ApplicationLayer
{
    public static void AddApplicationLayer(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
}
